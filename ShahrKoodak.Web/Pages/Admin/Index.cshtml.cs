using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.DTOs.Feature;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web
{
    [PermissionChecker(10)]


    public class IndexModel : PageModel
    {
        private IFeatureService _featureService;

        public IndexModel(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public void OnGet()
        {
        }
    }
}