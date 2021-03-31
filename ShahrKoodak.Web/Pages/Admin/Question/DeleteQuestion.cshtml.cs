using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Question
{
    public class DeleteQuestionModel : PageModel
    {
        private IQuestionService _questionService;

        public DeleteQuestionModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [BindProperty] public DataLayer.Entities.Question.Question Question { get; set; }
        public void OnGet(int id)
        {
            Question = _questionService.GetQuestionById(id);
        }

        public IActionResult OnPost(int id)
        {
            _questionService.DeleteQuestion(id);

            return RedirectToPage("Index");
        }
    }
}
