using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
        public int? ParentId { get; set; }
        public Menu Parent { get; set; }
        public bool DisplayInMainMenu { get; set; }
        public bool DisplayInFooterMenu { get; set; }
        public bool IsSecondLanguage { get; set; }
    }
}
