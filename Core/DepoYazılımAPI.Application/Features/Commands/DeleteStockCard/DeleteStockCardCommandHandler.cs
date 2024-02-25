using DepoYazılımAPI.Application.Repositorys;
using MediatR;

namespace DepoYazılımAPI.Application.Features.Commands.DeleteStockCard
{
    public class DeleteStockCardCommandHandler : IRequestHandler<DeleteStockCardCommandRequest, DeleteStockCardCommandResponse>
    {
        private readonly IStockCardWriteRepository _stockCardWriteRepository;
        public DeleteStockCardCommandHandler(IStockCardWriteRepository stockCardWriteRepository = null)
        {
            _stockCardWriteRepository = stockCardWriteRepository;
        }
        public  async Task<DeleteStockCardCommandResponse> Handle(DeleteStockCardCommandRequest request, CancellationToken cancellationToken)
        {
            await _stockCardWriteRepository.Remove(stock => stock.StockCode == request.stockCode);
           await _stockCardWriteRepository.SaveAsync();
            return new();
        }
    }
}
