using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.DTOs.Operator
{
    public class ShowOperatorRoleForAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SystemName { get; set; }
        public int SortIndex { get; set; }
        public bool IsActive { get; set; }
    }
}
