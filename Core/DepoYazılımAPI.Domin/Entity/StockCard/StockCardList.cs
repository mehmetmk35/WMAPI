using DepoYazılımAPI.Domin.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.StockCard
{
    public class StockCardList : BaseEntity
    {
        public int ID { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public int StockBalance { get; set; }
        public ICollection<Barcode> Barcode { get; set; }

    }
}
