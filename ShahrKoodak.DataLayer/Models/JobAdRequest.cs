using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class JobAdRequest
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int JobAdId { get; set; }
        public JobAd JobAd { get; set; }
        public string Description { get; set; }
        public bool? IsAccpeted { get; set; }
        public int? ValidatedBy { get; set; }
        public DateTime? ValidatedAt { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string InterviewInviteMessage { get; set; }
        public string ValidationNote { get; set; }
    }
}
