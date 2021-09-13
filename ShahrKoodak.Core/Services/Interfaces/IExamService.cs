using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Exam;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IExamService
    {
        List<ShowExamForAdminViewModel> GetExamsForAdmin();
        List<ShowExamInstanceForAdminViewModel> getInstanceForAdmin();
        List<ShowExamQuestionForAdminViewModel> GetExamQuestionForAdmin();
        int AddExam(Exam exam);
        int AddInstance(ExamInstance instance);
        int AddQuestion(ExamQuestion question, IFormFile imgBank);
        Exam GetExamById(int bankId);
        ExamInstance GetInstanceById(int bankId);
        ExamQuestion GetQuestionById(int bankId);
        int UpdateExam(Exam exam);
        int UpdateExamInstance(ExamInstance examInstance);
        int UpdateExamQuestion(ExamQuestion examQuestion, IFormFile imgArticle);
    }
}
