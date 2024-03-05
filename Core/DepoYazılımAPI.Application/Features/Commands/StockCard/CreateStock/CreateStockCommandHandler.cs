using DepoYazılımAPI.Application.Repositorys;

using MediatR;
using Microsoft.Extensions.Logging;

namespace DepoYazılımAPI.Application.Features.Commands.StockCard.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, CreateStockCommandResponse>
    {
        private readonly IStockCardWriteRepository _stockCardWriteRepository;
        readonly ILogger<CreateStockCommandHandler> _logger;

        public CreateStockCommandHandler(IStockCardWriteRepository stockCardWriteRepository, ILogger<CreateStockCommandHandler> logger)
        {
            _stockCardWriteRepository = stockCardWriteRepository;
            _logger = logger;
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
            _logger.LogInformation("Stock Card Created");
            return new();
        }
    }
}
