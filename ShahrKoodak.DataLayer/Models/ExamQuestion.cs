using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string Question { get; set; }
        public string Photo { get; set; }
        public string CorrectAnswer { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}
