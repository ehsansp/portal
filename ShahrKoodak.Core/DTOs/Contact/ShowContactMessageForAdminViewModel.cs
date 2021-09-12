using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Contact
{
    public class ShowContactMessageForAdminViewModel
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NationalCode { get; set; }
        public string Cellphone { get; set; }
        public string Title { get; set; }

    }
}
