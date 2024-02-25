using MediatR;

namespace DepoYazılımAPI.Application.Features.Queries.StockCardImageFile
{
    public class StockCardImageFileQueryHandler : IRequestHandler<StockCardImageFileQueryRequest, StockCardImageFileQueryResponse>
    {
        public async Task<StockCardImageFileQueryResponse> Handle(StockCardImageFileQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
