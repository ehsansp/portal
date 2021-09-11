using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Province;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IProvinceService
    {
        List<ShowProvinceForAdminViewModel> GetProvinceForAdmin();
        int AddProvince(Province province);
        Province GetProvinceById(int provinceId);
        int UpdateProvince(Province province);
    }
}
