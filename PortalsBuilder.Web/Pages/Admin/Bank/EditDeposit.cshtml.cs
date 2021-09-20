using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Bank
{
    public class EditDepositModel : PageModel
    {
        private IArticleService _articleService;

        public EditDepositModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public void OnGet()
        {
        }
    }
}
