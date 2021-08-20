using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class OperatorRole
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SystemName { get; set; }
        public int SortIndex { get; set; }
        public bool IsActive { get; set; }
    }
}
