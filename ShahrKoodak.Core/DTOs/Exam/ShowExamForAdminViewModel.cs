using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Exam
{
    public class ShowExamForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public int? QuestionsCount { get; set; }
        public bool IsActive { get; set; }
    }
}
