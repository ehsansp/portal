using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Exam
{
    public class ShowExamQuestionForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Question { get; set; }
        public string Photo { get; set; }
        public int SortIndex { get; set; }
    }
}
