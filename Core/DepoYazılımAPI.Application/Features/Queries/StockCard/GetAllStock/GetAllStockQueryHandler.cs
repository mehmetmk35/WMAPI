using DepoYazılımAPI.Application.Repositorys;
using MediatR;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.StockCard.GetAllStock
{
    public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQueryRequest, GetAllStockQueryResponse>
    {
        readonly IStockCardReadRepository _stockCardReadRepository;
        public GetAllStockQueryHandler(IStockCardReadRepository stockCardReadRepository)
        {
            _stockCardReadRepository = stockCardReadRepository;
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
            return new() { StockList = stockList, TotalCount = totalCount };

        }
    }
}
