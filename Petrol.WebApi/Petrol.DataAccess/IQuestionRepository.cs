using System.Collections.Generic;
using System.Threading.Tasks;
using Petrol.DataAccess.Entities;

namespace Petrol.DataAccess
{
    public interface IQuestionRepository
    {
        Task AddAsync(Question question);
        Task DeleteAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task UpdateAsync(int id, Question question);
    }
}