using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.EducationLevel;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class EducationService: IEducationService
    {
        private ShahrContext _context;

        public EducationService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowEducationLevelForAdminViewModel> GetEducationsForAdmin()
        {
            return _context.EducationLevels.Select(c => new ShowEducationLevelForAdminViewModel()
            {
                EnTitle = c.EnTitle,
                Id = c.Id,
                SortIndex = c.SortIndex,
                Title = c.EnTitle
            }).ToList();
        }

        public int AddEducation(EducationLevel education)
        {
            _context.Add(education);
            _context.SaveChanges();
            return education.Id;
        }

        public EducationLevel GetEducationById(int educationId)
        {
            return _context.EducationLevels.Find(educationId);
        }

        public int UpdateEducation(EducationLevel education)
        {
            _context.EducationLevels.Update(education);
            _context.SaveChanges();
            return education.Id;
        }
    }
}
