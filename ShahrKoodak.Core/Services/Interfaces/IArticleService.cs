using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IArticleService
    {
        List<ShowArticleForAdminViewModel> GetArticlesForAdmin();
        List<ArticleCategory> GetCategoryArticlesForAdmin();
        int AddArticle(Article article, IFormFile imgArticle);
        Article GetArticleById(int articleId);
        int AddGroup(ArticleCategory group);
        ArticleCategory GetById(int groupId);
        int UpdateGroup(ArticleCategory group);
        List<SelectListItem> GetGroupForManageArticle();
    }
}
