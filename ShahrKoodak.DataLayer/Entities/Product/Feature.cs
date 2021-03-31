using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        [Display(Name = "عنوان ویژگی")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string FeatureTitle { get; set; }

        public int GroupId { get; set; }

        #region Relations

        public virtual List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductGroup> ProductGroups { get; set; }
        public List<FeatureGroup> FeatureGroups { get; set; }

        #endregion
    }
}
