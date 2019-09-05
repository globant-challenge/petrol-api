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

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _petrolDbContext.Questions.FindAsync(id);
            _petrolDbContext.Remove(entityToDelete);

            await _petrolDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Question question)
        {
            var entityToUpdate = await _petrolDbContext.Questions.FindAsync(id);

            entityToUpdate.AskedQuestion = question.AskedQuestion;
            entityToUpdate.Answer = question.Answer;

            await _petrolDbContext.SaveChangesAsync();
        }
    }
}
