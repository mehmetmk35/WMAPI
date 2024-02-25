using DepoYazılımAPI.Domain.RequestParameters;
using MediatR;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.StockCard.GetAllStock
{
    public class GetAllStockQueryRequest : IRequest<GetAllStockQueryResponse>
    {
        //public Pagination pagination { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
