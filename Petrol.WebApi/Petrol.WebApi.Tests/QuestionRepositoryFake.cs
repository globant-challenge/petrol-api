using Petrol.DataAccess;
using Petrol.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petrol.WebApi.Tests
{
    public class QuestionRepositoryFake : IQuestionRepository
    {
        public async Task AddAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public  async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 0,
                    Answer = "a",
                    AskedQuestion = "b"
                }
            };
        }

        public async Task UpdateAsync(int id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
