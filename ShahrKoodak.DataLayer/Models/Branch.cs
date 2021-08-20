using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string ManagerName { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public string City { get; set; }
        public string WorkTimes { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string  Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public bool DisplayInContactPage { get; set; }
        public bool IsSecondLanguage { get; set; }

    }
}
