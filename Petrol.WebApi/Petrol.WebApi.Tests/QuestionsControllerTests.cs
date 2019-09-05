using Microsoft.AspNetCore.Mvc;
using Petrol.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Petrol.WebApi.Tests
{
    public class QuestionsControllerTests
    {
        [Fact]
        public async Task Should_ReturnOkObjectResult_When_QuestionsAreFound()
        {
            //Arrange
            var repository = new QuestionRepositoryFake();
            var controller = new Controllers.QuestionsController(repository);

            //Act
            var actionResult = await controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Should_ReturnNotFound_When_UpdatingQuestionsDoesntExist()
        {
            //Arrange
            var repository = new NotFoundQuestionsRepositoryFake();
            var controller = new Controllers.QuestionsController(repository);

            //Act
            var actionResult = await controller.Put(1, new Model.QuestionModel());

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Should_ReturnNotFound_When_DeletingQuestionsDoesntExist()
        {
            //Arrange
            var repository = new NotFoundQuestionsRepositoryFake();
            var controller = new Controllers.QuestionsController(repository);

            //Act
            var actionResult = await controller.Delete(1);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}
