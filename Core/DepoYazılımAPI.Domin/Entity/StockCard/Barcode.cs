using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.StockCard
{
    public class Barcode
    {
        public int ID { get; set; }
        public StockCardRecord StockCode { get; set; }
        public long Barcodes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
