using DepoYazılımAPI.Domin.Entity.StockCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.FileUpload
{
    public class StockCardImageFile:File
    {
        public ICollection<StockCardRecord> StockCardRecord { get; set; }

    }
}
