using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public int CategoryId { get; set; }
        public FAQCategory Category { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}
