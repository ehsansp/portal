using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class ArticleCategory
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public int SortIndex { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public List<ArticleCategory> Parent { get; set; }
        public bool IsSecondLanguage { get; set; }


        [InverseProperty("ArticleCategory")]
        public List<Article> Articles { get; set; }

        [InverseProperty("Group")]
        public List<Article> SubGroup { get; set; }
    }
}
