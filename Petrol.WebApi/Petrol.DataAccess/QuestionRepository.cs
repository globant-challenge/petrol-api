using Petrol.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Petrol.DataAccess
{
    /// <summary>
    /// Repository for managing the questions
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PetrolDbContext _petrolDbContext;

        public QuestionRepository(PetrolDbContext petrolDbContext) => _petrolDbContext = petrolDbContext;


        /// <summary>
        /// Inserts a new question
        /// </summary>
        /// <param name="question">The question to insert</param>
        /// <returns></returns>
        public async Task AddAsync(Question question)
        {
            _petrolDbContext.Add(question);
            await _petrolDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all the questions in a single query
        /// </summary>
        /// <returns>The list of questions</returns>
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _petrolDbContext.Questions.ToListAsync();
        }

        /// <summary>
        /// Deletes a question by its id
        /// </summary>
        /// <param name="id">The id of the question to delete</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _petrolDbContext.Questions.FindAsync(id);

            if (entityToDelete == null)
            {
                throw new EntityNotFoundException();
            }

            _petrolDbContext.Remove(entityToDelete);

            await _petrolDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a question by its id
        /// </summary>
        /// <param name="id">The id of the question to update</param>
        /// <param name="question">The question to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, Question question)
        {
            var entityToUpdate = await _petrolDbContext.Questions.FindAsync(id);

            if (entityToUpdate == null)
            {
                throw new EntityNotFoundException();
            }

            entityToUpdate.AskedQuestion = question.AskedQuestion;
            entityToUpdate.Answer = question.Answer;

            await _petrolDbContext.SaveChangesAsync();
        }
    }
}
