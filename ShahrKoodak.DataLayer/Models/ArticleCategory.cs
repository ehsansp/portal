using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class ArticleCategory
    {
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
        public List<ArticleCategory> Parent { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
