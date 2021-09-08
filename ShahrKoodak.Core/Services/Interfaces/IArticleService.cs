using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IArticleService
    {
        List<ShowArticleForAdminViewModel> GetArticlesForAdmin();
        int AddArticle(Article article, IFormFile imgArticle);
        Article GetArticleById(int articleId);
    }
}
