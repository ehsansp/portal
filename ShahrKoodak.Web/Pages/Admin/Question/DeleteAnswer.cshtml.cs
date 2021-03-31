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
    public class DeleteAnswerModel : PageModel
    {
        private IQuestionService _questionService;

        public DeleteAnswerModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [BindProperty] public Answer Answer { get; set; }
        public void OnGet(int id)
        {
            Answer = _questionService.GetAnswerById(id);
        }

        public IActionResult OnPost(int id)
        {
            _questionService.DeleteAnswer(id);

            return RedirectToPage("Index");
        }
    }
}
