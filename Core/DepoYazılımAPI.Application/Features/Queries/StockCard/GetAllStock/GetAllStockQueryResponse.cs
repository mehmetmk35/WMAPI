using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Queries.StockCard.StockCard.GetAllStock
{
    public class GetAllStockQueryResponse
    {
        public int TotalCount { get; set; }
        public object StockList { get; set; }
    }
}
