using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Notification
{
    public class ShowNotificationForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public int ClickCount { get; set; }
    }
}
