using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public ContactMessageCategory Cateogry { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string NationalCode { get; set; }
        public string Cellphone { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrackingCode { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string ReviewNote { get; set; }
    }
}
