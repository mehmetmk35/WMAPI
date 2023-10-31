using DepoYazılımAPI.Application.Abstractions;
using DepoYazılımAPI.Domin.Entity.StockCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Concretes
{
    public class StockCardListService : IStockCardListService
    {
        public List<StockCardList> GetStockCardList()
            => new() {
                      new() {StockCode="test1",Barcode={new() { Barcodes=1} } ,StockBalance=21,StockName="test2"},
                      new() {StockCode="test3",Barcode={new() { Barcodes=12} },StockBalance=21,StockName="test4"},
                      new() {StockCode="test5",Barcode={new() { Barcodes=123} },StockBalance=21,StockName="test6"}

                    };
         
    }
}
