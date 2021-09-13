using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.FAQ;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IFAQService
    {
        List<ShowFAQCategoryForAdminVieWModel> GetFAQCaregoriesForAdmin();
        List<ShowFAQForAdminViewModel> GetFAQsForAdmin();
        int AddFAQ(FAQ faq, IFormFile imgBank);
        int AddFAQCategory(FAQCategory faqCategory);
        FAQ GetFAQById(int faqId);
        FAQCategory GetFaqCategoryById(int categoryId);
        int UpdateFAQ(FAQ faq, IFormFile imgArticle);
        int UpdateFAQCategory(FAQCategory faqCategory);
    }
}
