using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Question;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IQuestionService
    {
        List<ShowQuestionnaireForAdminViewModel> getQuestionireForAdminViewModels();
        List<ShowQuestionnaireInstanceForAdminViewModel> getQuestionInstanceForAdminViewModels();
        List<ShowQuestionnaireQuestionForAdminViewModel> getQuestionForAdminViewModels();
        int AddQuestionire(Questionnaire questionnaire);
        int AddInstance(QuestionnaireInstance questionnaireInstance);
        int AddQuestion(QuestionnaireQuestion question, IFormFile imgBank);
        Questionnaire GetQuestionnireById(int questionnireId);
        QuestionnaireInstance GetInstanceById(int instanceId);
        QuestionnaireQuestion GetQuestionById(int questionId);
        int UpdateQuestionnire(Questionnaire questionnaire);
        int UpdateInstance(QuestionnaireInstance instance);
        int UpdateQuestion(QuestionnaireQuestion question, IFormFile imgArticle);

    }
}
