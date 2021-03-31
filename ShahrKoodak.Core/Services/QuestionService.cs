using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Question;

namespace ShahrKoodak.Core.Services
{
    public class QuestionService:IQuestionService
    {
        private ShahrContext _context;

        public QuestionService(ShahrContext context)
        {
            _context = context;
        }
        public List<Question> GetAllQuestion()
        {
            return _context.Questions.ToList();
        }

        public int AddQuestion(Question question)
        {
            _context.Add(question);
            _context.SaveChanges();
            return question.QuestionId;
        }

        public int AddAnswer(Answer answer)
        {
            _context.Add(answer);
            _context.SaveChanges();
            return answer.QuestionId;
        }

        public Question GetQuestionById(int questionId)
        {
            return _context.Questions.Find(questionId);
        }

        public Answer GetAnswerById(int answerId)
        {
            return _context.Answers.Find(answerId);
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }

        public List<Answer> GetListAnswers(int questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId).ToList();
        }

        public void DeleteQuestion(int questionId)
        {
            Question question = GetQuestionById(questionId);
            _context.Entry(question).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteAnswer(int answerId)
        {
            Answer answer = GetAnswerById(answerId);
            _context.Entry(answer).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
