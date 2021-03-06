using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Writer { get; set; }
        public string Photo { get; set; }
        public string Detail { get; set; }
        public string Keywords { get; set; }
        public DateTime? PublishAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public bool SendAsNewsLetter { get; set; }
        public int ArticleCategoryId { get; set; }
        public int? SubGroup { get; set; }
        public int ViewCount { get; set; }
        public bool IsSecondLanguage { get; set; }


        [ForeignKey("ArticleCategoryId")]
        public ArticleCategory ArticleCategory { get; set; }

        [ForeignKey("SubGroup")]
        public ArticleCategory Group { get; set; }
    }
}
