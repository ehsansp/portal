using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Slide;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Slide
{
    public class IndexModel : PageModel
    {
        private ISlideService _slideService;

        public IndexModel(ISlideService slideService)
        {
            _slideService = slideService;
        }
        public List<ShowSlideForeAdminVierwModel> ListSlide { get; set; }
        public void OnGet()
        {
            ListSlide = _slideService.getSlideForAdminViewModels();
        }
    }
}
