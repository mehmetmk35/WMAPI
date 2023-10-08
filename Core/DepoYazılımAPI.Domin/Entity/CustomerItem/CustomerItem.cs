using DepoYazılımAPI.Domin.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.CustomerItem
{
    public class CustomerItem : BaseEntity
    {

        public string ID { get; set; }
        public string? BusinessCode { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerDistrict { get; set; }
        public string? CountryCode { get; set; }
        public string? CustomerName { get; set; }
        public string? GroupCode { get; set; }
        public string? CustomerAddress { get; set; }
        public string? MK1 { get; set; }
        public string? MK2 { get; set; }
        public DateTime? Date { get; set; }
    }

}
