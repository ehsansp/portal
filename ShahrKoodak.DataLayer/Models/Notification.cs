using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
        public string Detail { get; set; }
        public DateTime? PublishAt { get; set; }
        public bool IsActive { get; set; }
        public bool SendAsNewsLetter { get; set; }
        public bool DisplayAsPopUp { get; set; }
        public int ClickCount { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
