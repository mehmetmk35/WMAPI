using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.Common
{
    public class BaseEntity
    {      // virtual yapmamın sebebi DB  mig. işlemi yapmak istemiyeceğim classlar için override ile  [NotMapped] işaretliyorum 
        public string CompanyName { get; set; }         
        public int BranchCode { get; set; } 
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        virtual public string? UpdatedBy { get; set; }
        virtual public DateTime? UpdatedAt { get; set; }
        virtual public DateTime? DeletedDate { get; set; }
        virtual public bool IsDeleted { get; set; }

    }
}
