using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Commands.DeleteStockCard
{
    public class DeleteStockCardCommandRequest:IRequest<DeleteStockCardCommandResponse>
    {
        public string stockCode { get; set; }
    }
}
