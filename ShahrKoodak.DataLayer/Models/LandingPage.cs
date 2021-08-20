using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class LandingPage
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string RouteTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string BackgroundPhoto { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
        public string LinkTitle { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string EndingMessage { get; set; }
        public string EndingLink { get; set; }
        public string EndingLinkTitle { get; set; }
        public bool IsActive { get; set; }
        public bool UseDarkTheme { get; set; }
        public bool ShowCountdownBeforeStart { get; set; }
        public string CountdownMessage { get; set; }
        public bool ShowCountdownToEnd { get; set; }
        public int ClickCount { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
