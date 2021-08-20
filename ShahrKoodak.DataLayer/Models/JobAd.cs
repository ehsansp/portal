using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class JobAd
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Keywords { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public string City { get; set; }
        public int? MinEducationLevelId { get; set; }
        public EducationLevel MinEducationLevel { get; set; }
        public bool MaleIsAccepted { get; set; }
        public bool FemaleIsAccepted { get; set; }
        public bool IsFulltime { get; set; }
        public bool IsPartTime { get; set; }
        public bool IsOutsource { get; set; }
        public bool IsInternship { get; set; }
        public DateTime? PublishAt { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public string SendRequestsToEmails { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
