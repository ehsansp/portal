using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Question
{
    public class EditQuestionModel : PageModel
    {
        private IQuestionService _questionService;

        public EditQuestionModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [BindProperty] public DataLayer.Entities.Question.Question Question { get; set; }
        public void OnGet(int id)
        {
            Question = _questionService.GetQuestionById(id);
        }

        public IActionResult OnPost()
        {
            _questionService.UpdateQuestion(Question);

            return RedirectToPage("Index");
        }
    }
}
