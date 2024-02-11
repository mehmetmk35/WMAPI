using DepoYazılımAPI.Domin.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Domin.Entity.FileUpload
{
    public class File:BaseEntity
    {
        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
       
        [NotMapped]
        public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
        [NotMapped]
        public override string? UpdatedBy { get => base.UpdatedBy; set => base.UpdatedBy = value; }
        public int ID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

    }
}
