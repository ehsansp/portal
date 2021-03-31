using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class FeatureGroup
    {
        [Key]
        public int FG_ID { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int FeatureId { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int ProductGroupId { get; set; }


        public Feature Feature { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
