using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Question
{
    public class ShowQuestionnaireForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
