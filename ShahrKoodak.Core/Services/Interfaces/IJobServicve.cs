using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Job;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IJobServicve
    {
        List<SelectListItem> GetProvinceForManageBranch();
        List<SelectListItem> GetJobForManage();
        List<SelectListItem> GetEducationLevelForManageBranch();
        List<ShowJobAdForAdminViewModel> GetJobAdsForAdmin();
        List<ShowJobAdRequestForAdminViewModel> GetJobAdRequestsForAdmin();
        int AddJobAd(JobAd jobAd);
        int AddJobRequest(JobAdRequest jobAdRequest);
        JobAd GetJobAdById(int jobId);
        JobAdRequest GetJobAdRequestById(int jobRequestId);
        int UpdateJob(JobAd jobAd);
        int UpdateJobRequest(JobAdRequest jobAdRequest);
    }
}
