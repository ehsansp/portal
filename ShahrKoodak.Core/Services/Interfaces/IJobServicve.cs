using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Job;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IJobServicve
    {
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
