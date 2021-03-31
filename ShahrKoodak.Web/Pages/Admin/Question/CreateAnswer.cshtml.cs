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
    public class CreateAnswerModel : PageModel
    {
        private IQuestionService _questionService;

        public CreateAnswerModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [BindProperty] public Answer Answer { get; set; }
        public void OnGet(int id)
        {
            Answer = new Answer();
            Answer.QuestionId = id;
        }

        public IActionResult OnPost()
        {
            _questionService.AddAnswer(Answer);

            return Redirect("/Admin/Question/AnswerIndex/" + Answer.QuestionId);
        }
    }
}
