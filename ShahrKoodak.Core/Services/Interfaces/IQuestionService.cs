using System;
using System.Collections.Generic;
using System.Text;
using ShahrKoodak.DataLayer.Entities.Question;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IQuestionService
    {
        List<Question> GetAllQuestion();
        int AddQuestion(Question question);
        int AddAnswer(Answer answer);
        Question GetQuestionById(int questionId);
        Answer GetAnswerById(int answerId);
        void UpdateQuestion(Question question);
        void UpdateAnswer(Answer answer);
        List<Answer> GetListAnswers(int questionId);
        void DeleteQuestion(int questionId);
        void DeleteAnswer(int answerId);
    }
}
