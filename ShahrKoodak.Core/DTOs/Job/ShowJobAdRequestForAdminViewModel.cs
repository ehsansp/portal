using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Job
{
    public class ShowJobAdRequestForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ValidatedBy { get; set; }
        public DateTime? ValidatedAt { get; set; }
    }
}
