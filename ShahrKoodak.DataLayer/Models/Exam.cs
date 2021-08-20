using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInMinute { get; set; }
        public int? QuestionsCount { get; set; }
        public bool IsActive { get; set; }
        public bool UseRandomQuestions { get; set; }
        public int CorrectAnswerPoint { get; set; }
        public int WrongAnswerNegativePoint { get; set; }
        public DateTime? PublishAt { get; set; }
        public DateTime? ExpireAt { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
