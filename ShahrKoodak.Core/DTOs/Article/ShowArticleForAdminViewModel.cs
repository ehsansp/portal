using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Models;

namespace PortalBuilder.Core.DTOs.Article
{
   public class ShowArticleForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int? ArticleCategoryId { get; set; }
        public string ArticleCategoryTitle { get; set; }
        public int ViewCount { get; set; }
    }
}
