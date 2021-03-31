using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.Question;

namespace ShahrKoodak.Web.Pages.Admin.Question
{
    public class AnswerIndexModel : PageModel
    {
        private IQuestionService _questionService;

        public AnswerIndexModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<Answer> Answers { get; set; }
        public void OnGet(int id)
        {
            ViewData["QuestionId"] = id;
            Answers = _questionService.GetListAnswers(id);
        }
    }
}
