using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Question
{
    public class ShowQuestionnaireQuestionForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Question { get; set; }
        public string Photo { get; set; }
    }
}
