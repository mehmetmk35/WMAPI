using DepoYazılımAPI.Domin.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.StockCard
{
    public class StockCardRecord : BaseEntity
    {
        public int ID { get; set; }      
        public string StockCode { get; set; }
        public string? StockName { get; set; }
        public string? GroupCode { get; set; }
        public string? Code1 { get; set; }
        public string? Code2 { get; set; }
        public string? Code3 { get; set; }
        public string? Code4 { get; set; }      
        public string? UnitOfMeasure1 { get; set; }
        public string? UnitOfMeasure2 { get; set; }
        public string? UnitOfMeasure3 { get; set; }
        public decimal? UnitOfMeasure1Denominator { get; set; }
        public decimal? UnitOfMeasure1Numerator { get; set; }
        public decimal? UnitOfMeasure2Denominator { get; set; }
        public decimal? UnitOfMeasure2Numerator { get; set; }
        public long? SellingPrice1 { get; set; }
        public decimal? SellingPrice2 { get; set; }
        public decimal? VATRate { get; set; }
        public string? PurchaseVATCode { get; set; }
        public string? WarehouseCode { get; set; }
        public decimal? PurchasePrice1 { get; set; }
        public decimal? PurchasePrice2 { get; set; }
        public ICollection<Barcode>? barcodes { get; set; }//burası kontrol edilcektir 
        public bool?  Lock { get; set; }
        public string? AdditionalFields { get; set; }
        public string? MK1 { get; set; }
        public string? MK2 { get; set; }

       

    }
}
