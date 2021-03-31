using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Question
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; }
        public Question Question { get; set; }
    }
}
