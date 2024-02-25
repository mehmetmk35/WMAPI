using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Domin.Entity.StockCard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.GetStockByStockCode
{
    public class GetStockByStockCodeQueriesHandler : IRequestHandler<GetStockByStockCodeQueriesRequest, GetStockByStockCodeQueriesResponse>
    {
        private readonly IStockCardReadRepository _stockCardReadRepository;

        public GetStockByStockCodeQueriesHandler(IStockCardReadRepository stockCardReadRepository)
        {
            _stockCardReadRepository = stockCardReadRepository;
        }

         
        public async Task<GetStockByStockCodeQueriesResponse> Handle(GetStockByStockCodeQueriesRequest request, CancellationToken cancellationToken)
        {
            StockCardRecord response= await _stockCardReadRepository.GetSingleAsync(x => x.StockCode == request.StockCode);
            return new() { StockCode = response.StockCode,StockName=response.StockName };
        }
    }
}
