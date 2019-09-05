using Petrol.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Petrol.DataAccess
{
    public class QuestionRepository
    {
        private readonly PetrolDbContext _petrolDbContext;

        public QuestionRepository(PetrolDbContext petrolDbContext) => _petrolDbContext = petrolDbContext;


        public async Task AddAsync(Question question)
        {
            _petrolDbContext.Add(question);
            await _petrolDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _petrolDbContext.Questions.ToListAsync();
        }
    }
}
