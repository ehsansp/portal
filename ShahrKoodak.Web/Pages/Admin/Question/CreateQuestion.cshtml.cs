using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Question
{
    public class CreateQuestionModel : PageModel
    {
        private IQuestionService _questionService;

        public CreateQuestionModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [BindProperty] public DataLayer.Entities.Question.Question Question { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _questionService.AddQuestion(Question);

            return RedirectToPage("Index");
        }
    }
}
