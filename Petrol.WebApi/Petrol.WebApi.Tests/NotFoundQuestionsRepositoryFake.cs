using Petrol.DataAccess;
using Petrol.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petrol.WebApi.Tests
{
    public class NotFoundQuestionsRepositoryFake : IQuestionRepository
    {
        public async Task AddAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new EntityNotFoundException();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return new List<Question>();
        }

        public async Task UpdateAsync(int id, Question question)
        {
            throw new EntityNotFoundException();
        }
    }
}
