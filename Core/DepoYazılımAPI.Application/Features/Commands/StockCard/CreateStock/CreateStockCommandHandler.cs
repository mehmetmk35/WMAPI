using DepoYazılımAPI.Application.Repositorys;

using MediatR;

namespace DepoYazılımAPI.Application.Features.Commands.StockCard.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, CreateStockCommandResponse>
    {
        private readonly IStockCardWriteRepository _stockCardWriteRepository;

        public CreateStockCommandHandler(IStockCardWriteRepository stockCardWriteRepository)
        {
            _stockCardWriteRepository = stockCardWriteRepository;
        }

      
        public async Task<CreateStockCommandResponse> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            
            await _stockCardWriteRepository.AddAsync(new()
            {
                StockCode = request.StockCode,
                CompanyName = request.CompanyName,
                BranchCode = request.BranchCode,
                CreatedBy = request.CreatedBy
            });
            await _stockCardWriteRepository.SaveAsync();
            return new();
        }
    }
}
