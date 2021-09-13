using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Page;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IPageService
    {
        List<ShowPageForAdminViewModel> getPagesForAdminViewModels();
        int AddPage(Page page);
        Page GetPageById(int pageId);
        int UpdatePage(Page page);
    }
}
