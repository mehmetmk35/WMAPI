using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.Common
{
    public class BaseEntity
    {      
        public string CompanyName { get; set; }         
        public int BranchCode { get; set; } 
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
