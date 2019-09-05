using Microsoft.AspNetCore.Mvc;
using Petrol.DataAccess;
using Petrol.DataAccess.Entities;
using Petrol.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrol.WebApi.Controllers
{
    /// <summary>
    /// Controller for the question resources
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository) => _questionRepository = questionRepository;

        /// <summary>
        /// Gets all the questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> Get()
        {
            var entities = await _questionRepository.GetAllAsync();

            var models = new List<QuestionModel>();

            foreach (var entity in entities)
            {
                models.Add(new QuestionModel
                {
                    Id = entity.Id,
                    Question = entity.AskedQuestion,
                    Answer = entity.Answer
                });
            }

            return Ok(models);

        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Inserts a new question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<QuestionModel>> Post([FromBody] QuestionModel question)
        {
            await _questionRepository.AddAsync(new DataAccess.Entities.Question
            {
                AskedQuestion = question.Question,
                Answer = question.Answer
            });

            return Created(string.Empty, question);
        }

        /// <summary>
        /// Updates a question by its id
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="question">The question to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] QuestionModel question)
        {
            try
            {
                await _questionRepository.UpdateAsync(id, new Question
                {
                    AskedQuestion = question.Question,
                    Answer = question.Answer
                });
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }            

            return Ok();
        }
                
        /// <summary>
        /// Deletes a question by its id
        /// </summary>
        /// <param name="id">The id of the question to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _questionRepository.DeleteAsync(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok();
        }
    }
}
