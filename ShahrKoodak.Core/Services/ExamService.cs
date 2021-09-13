using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Exam;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class ExamService: IExamService
    {
        private ShahrContext _context;

        public ExamService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowExamForAdminViewModel> GetExamsForAdmin()
        {
            return _context.Exams.Select(c => new ShowExamForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                QuestionsCount = c.QuestionsCount,
                Title = c.Title
            }).ToList();
        }

        public List<ShowExamInstanceForAdminViewModel> getInstanceForAdmin()
        {
            return _context.ExamInstances.Select(c => new ShowExamInstanceForAdminViewModel()
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                QAs = c.QAs,
                Score = c.Score
            }).ToList();
        }

        public List<ShowExamQuestionForAdminViewModel> GetExamQuestionForAdmin()
        {
            return _context.ExamQuestions.Select(c => new ShowExamQuestionForAdminViewModel()
            {
                Photo = c.Photo,
                SortIndex = c.SortIndex,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Question = c.Question
            }).ToList();
        }

        public int AddExam(Exam exam)
        {
            _context.Add(exam);
            _context.SaveChanges();
            return exam.Id;
        }

        public int AddInstance(ExamInstance instance)
        {
            _context.Add(instance);
            _context.SaveChanges();
            return instance.Id;
        }

        public int AddQuestion(ExamQuestion question, IFormFile imgBank)
        {
            question.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                question.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", question.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", question.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            question.CreatedAt=DateTime.Now;
            _context.Add(question);
            _context.SaveChanges();
            return question.Id;
        }

        public Exam GetExamById(int bankId)
        {
            return _context.Exams.Find(bankId);
        }

        public ExamInstance GetInstanceById(int bankId)
        {
            return _context.ExamInstances.Find(bankId);
        }

        public ExamQuestion GetQuestionById(int bankId)
        {
            return _context.ExamQuestions.Find(bankId);
        }

        public int UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
            return exam.Id;
        }

        public int UpdateExamInstance(ExamInstance examInstance)
        {
            _context.ExamInstances.Update(examInstance);
            _context.SaveChanges();
            return examInstance.Id;
        }

        public int UpdateExamQuestion(ExamQuestion examQuestion, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                examQuestion.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", examQuestion.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", examQuestion.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.ExamQuestions.Update(examQuestion);
            _context.SaveChanges();
            return examQuestion.Id;
        }
    }
}
