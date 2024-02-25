using MediatR;

namespace DepoYazılımAPI.Application.Features.Commands.StockCard.CreateStock
{
    public class CreateStockCommandRequest:IRequest<CreateStockCommandResponse>
    {
        //baseden gelenler için kalıtım aldırılacaktır

        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public int BranchCode { get; set; }
    }
}
