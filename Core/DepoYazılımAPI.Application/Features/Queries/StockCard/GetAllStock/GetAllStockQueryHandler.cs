using DepoYazılımAPI.Application.Repositorys;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.StockCard.GetAllStock
{
    public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, GetAllStockQueryResponse>
    {
        readonly IStockCardReadRepository _stockCardReadRepository;
        readonly ILogger<GetAllStockQueryHandler> _logger;
        public GetAllStockQueryHandler(IStockCardReadRepository stockCardReadRepository, ILogger<GetAllStockQueryHandler> logger)
        {
            _stockCardReadRepository = stockCardReadRepository;
            _logger = logger;
        }

        public async Task<GetAllStockQueryResponse> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _stockCardReadRepository.GetWhere(x => x.IsDeleted == false, false).Count();
            var stockList = _stockCardReadRepository.GetWhere(x => x.IsDeleted == false, false).Skip(request.Size * request.Page).Take(request.Size)
           .Select(x => new
           {
               x.StockCode,
               x.StockName,
               x.BranchCode,
               x.CreatedAt,
               x.CreatedBy
           });
            _logger.LogInformation("Stock Cards have been successfully listed");
            return new() { StockList = stockList, TotalCount = totalCount };

        }
    }
}
