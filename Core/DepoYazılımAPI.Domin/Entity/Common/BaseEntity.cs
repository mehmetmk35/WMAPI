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
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string BranchCode { get; set; }
    }
}
