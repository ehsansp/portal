using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Article;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IArticleService
    {
        List<ShowArticleForAdminViewModel> GetArticlesForAdmin();

    }
}
