using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class ProductFeature
    {
        public ProductFeature()
        {
            
        }
        [Key]
        public int PF_ID { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int FeatureId { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [Display(Name = "مقدار")]
        public string Value { get; set; }


        #region Relations

        public virtual product Product { get; set; }
        public virtual Feature Feature { get; set; }

        #endregion
    }
}
