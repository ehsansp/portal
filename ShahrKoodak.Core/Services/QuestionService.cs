using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Question;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class QuestionService: IQuestionService
    {
        private ShahrContext _context;

        public QuestionService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowQuestionnaireForAdminViewModel> getQuestionireForAdminViewModels()
        {
            return _context.Questionnaires.Select(c => new ShowQuestionnaireForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Title = c.Title,
                IsActive = c.IsActive,
                IsSecondLanguage = c.IsSecondLanguage
            }).ToList();
        }

        public List<ShowQuestionnaireInstanceForAdminViewModel> getQuestionInstanceForAdminViewModels()
        {
            return _context.QuestionnaireInstances.Select(c => new ShowQuestionnaireInstanceForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                QAs = c.QAs
            }).ToList();
        }

        public List<ShowQuestionnaireQuestionForAdminViewModel> getQuestionForAdminViewModels()
        {
            return _context.QuestionnaireQuestions.Select(c => new ShowQuestionnaireQuestionForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Photo = c.Photo,
                Question = c.Question
            }).ToList();
        }

        public int AddQuestionire(Questionnaire questionnaire)
        {
            questionnaire.CreatedAt = DateTime.Now;
            _context.Add(questionnaire);
            _context.SaveChanges();
            return questionnaire.Id;
        }

        public int AddInstance(QuestionnaireInstance questionnaireInstance)
        {
            questionnaireInstance.CreatedAt=DateTime.Now;
            _context.Add(questionnaireInstance);
            _context.SaveChanges();
            return questionnaireInstance.Id;
        }

        public int AddQuestion(QuestionnaireQuestion question, IFormFile imgBank)
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

        public Questionnaire GetQuestionnireById(int questionnireId)
        {
            return _context.Questionnaires.Find(questionnireId);
        }

        public QuestionnaireInstance GetInstanceById(int instanceId)
        {
            return _context.QuestionnaireInstances.Find(instanceId);
        }

        public QuestionnaireQuestion GetQuestionById(int questionId)
        {
            return _context.QuestionnaireQuestions.Find(questionId);
        }

        public int UpdateQuestionnire(Questionnaire questionnaire)
        {
            _context.Questionnaires.Update(questionnaire);
            _context.SaveChanges();
            return questionnaire.Id;
        }

        public int UpdateInstance(QuestionnaireInstance instance)
        {
            _context.QuestionnaireInstances.Update(instance);
            _context.SaveChanges();
            return instance.Id;
        }

        public int UpdateQuestion(QuestionnaireQuestion question, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                question.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", question.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", question.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.QuestionnaireQuestions.Update(question);
            _context.SaveChanges();
            return question.Id;
        }
    }
}
