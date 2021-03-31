using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Question
{
    public class IndexModel : PageModel
    {
        private IQuestionService _questionService;

        public IndexModel(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<DataLayer.Entities.Question.Question> Questions { get; set; }
        public void OnGet()
        {
            Questions = _questionService.GetAllQuestion();
        }
    }
}
