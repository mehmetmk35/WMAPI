using MediatR;
using Microsoft.AspNetCore.Http;

namespace DepoYazılımAPI.Application.Features.Commands.StockCardImageFile
{
    public class StockCardImageFileCommandRequest:IRequest<StockCardImageFileCommandResponse>
    {
        public string StockCode { get; set; }
        public IFormFileCollection FormCollection { get; set; }
    }
}
