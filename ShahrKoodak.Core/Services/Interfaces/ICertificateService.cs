using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Certificate;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ICertificateService
    {
        List<ShowCertificateForWebSiteViewModel> GetCertificateForAdmin();
        int AddCertificate(Certificate certificate, IFormFile imgBank);
        Certificate GetCertificateById(int certificateId);
        int UpdateCertificate(Certificate certificate, IFormFile imgArticle);
    }
}
