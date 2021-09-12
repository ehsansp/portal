using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.EducationLevel;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IEducationService
    {
        List<ShowEducationLevelForAdminViewModel> GetEducationsForAdmin();
        int AddEducation(EducationLevel education);
        EducationLevel GetEducationById(int educationId);
        int UpdateEducation(EducationLevel education);
    }
}
