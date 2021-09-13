using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Partner;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IPartnerService
    {
        List<ShowPartnerForAdminViewModel> getPartnerForAdminViewModels();
        int AddPartner(Partner partner);
        Partner GetPartnerById(int partnerId);
        int UpdatePartner(Partner partner);
    }
}
