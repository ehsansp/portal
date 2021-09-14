using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Staff;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IStaffService
    {
        List<ShowStaffForWebSiteViewModel> GetStaffForWebSite();

        List<ShowStaffForAdminViewModel> getStaffForAdminViewModels();
        List<ShowStaffPositionForAdminViewModel> getStaffPositionForAdminViewModels();
        int AddStaff(Staff staff, IFormFile imgBank);
        int AddStaffPosition(StaffPosition staffPosition);
        Staff GetStaffId(int staffId);
        StaffPosition GetStaffPositionById(int staffPositionId);
        int UpdateStaff(Staff staff, IFormFile imgArticle);
        int UpdateStaffPosition(StaffPosition staffPosition);
        List<SelectListItem> getStaffPositionItems();
    }
}
