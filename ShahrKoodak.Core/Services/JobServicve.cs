using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Job;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class JobServicve: IJobServicve
    {
        private ShahrContext _context;

        public JobServicve(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowJobAdForAdminViewModel> GetJobAdsForAdmin()
        {
            return _context.JobAds.Select(c => new ShowJobAdForAdminViewModel()
            {
                City = c.City,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Title = c.Title,
                ViewCount = c.ViewCount
            }).ToList();
        }

        public List<ShowJobAdRequestForAdminViewModel> GetJobAdRequestsForAdmin()
        {
            return _context.JobAdRequests.Select(c => new ShowJobAdRequestForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                ValidatedAt = c.ValidatedAt,
                ValidatedBy = c.ValidatedBy
            }).ToList();
        }

        public int AddJobAd(JobAd jobAd)
        {
            jobAd.CreatedAt=DateTime.Now;
            _context.Add(jobAd);
            _context.SaveChanges();
            return jobAd.Id;
        }

        public int AddJobRequest(JobAdRequest jobAdRequest)
        {
            jobAdRequest.CreatedAt=DateTime.Now;
            _context.Add(jobAdRequest);
            _context.SaveChanges();
            return jobAdRequest.Id;
        }

        public JobAd GetJobAdById(int jobId)
        {
            return _context.JobAds.Find(jobId);
        }

        public JobAdRequest GetJobAdRequestById(int jobRequestId)
        {
            return _context.JobAdRequests.Find(jobRequestId);
        }

        public int UpdateJob(JobAd jobAd)
        {
            _context.JobAds.Update(jobAd);
            _context.SaveChanges();
            return jobAd.Id;
        }

        public int UpdateJobRequest(JobAdRequest jobAdRequest)
        {
            _context.JobAdRequests.Update(jobAdRequest);
            _context.SaveChanges();
            return jobAdRequest.Id;
        }
    }
}
