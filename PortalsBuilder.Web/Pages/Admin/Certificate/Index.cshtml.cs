using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Certificate;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Certificate
{
    public class IndexModel : PageModel
    {
        private ICertificateService _certificateService;

        public IndexModel(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public List<ShowCertificateForWebSiteViewModel> ListCertificate { get; set; }
        public void OnGet()
        {
            ListCertificate = _certificateService.GetCertificateForAdmin();
        }
    }
}
