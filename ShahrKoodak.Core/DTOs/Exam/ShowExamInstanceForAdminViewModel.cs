using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Exam
{
   public  class ShowExamInstanceForAdminViewModel
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Score { get; set; }
        public string QAs { get; set; }
    }
}
