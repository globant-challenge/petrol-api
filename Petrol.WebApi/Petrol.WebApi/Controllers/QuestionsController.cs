using Microsoft.AspNetCore.Mvc;
using Petrol.DataAccess;
using Petrol.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrol.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionsController(QuestionRepository questionRepository) => _questionRepository = questionRepository;


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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
