using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalBuilder.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photographer { get; set; }
        public bool IsActive { get; set; }
        public int SortIndex { get; set; }
        public int? GalleryId { get; set; }
        public PhotoGallery Gallery { get; set; }
    }
}
