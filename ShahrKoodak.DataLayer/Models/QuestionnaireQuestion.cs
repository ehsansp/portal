using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class QuestionnaireQuestion
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public string Question { get; set; }
        public string Photo { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string OptionF { get; set; }
        public int OptionACount { get; set; }
        public int OptionBCount { get; set; }
        public int OptionCCount { get; set; }
        public int OptionDCount { get; set; }
        public int OptionECount { get; set; }
        public int OptionFCount { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
    }
}
