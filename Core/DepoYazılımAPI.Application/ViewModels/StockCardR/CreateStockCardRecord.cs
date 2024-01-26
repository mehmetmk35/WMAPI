using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.ViewModels.StockCardR
{
    public class CreateStockCardRecord
    {

        //baseden gelenler için kalıtım aldırılacaktır

        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
        public int BranchCode { get; set; }
    }
}
