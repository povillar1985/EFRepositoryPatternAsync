using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using XYZCorp.WebApi.Controllers;
using XYZCorp.WebApi.Models;

/// <summary>
/// Developer: Peter Gil O. Villar
/// </summary>
namespace XYZCorp.WebApi.Tests.Controllers
{
    [TestFixture]
    public class ValuesControllerTest
    {
        [Test]
        public void Get_ReturnType_ListOfUser()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IHttpActionResult result = controller.Get();
            var contentResult = result as OkNegotiatedContentResult<List<User>>;

            // Assert
            Assert.IsInstanceOf<List<User>>(contentResult.Content);
        }

        [Test]
        public void Get_ReturnCount_Two()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IHttpActionResult result = controller.Get();
            var contentResult = result as OkNegotiatedContentResult<List<User>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(2, contentResult.Content.Count());
        }

        [Test]
        public void Get_ById_NotFoundType()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IHttpActionResult result = controller.Get(-1);
            var contentResult = result as NotFoundResult;

            // Assert
            Assert.IsInstanceOf(typeof(NotFoundResult), contentResult);
        }

        [Test]
        public void Get_ById_FoundTypeOfUser()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IHttpActionResult result = controller.Get(2);
            var contentResult = result as OkNegotiatedContentResult<User>;

            // Assert
            Assert.IsInstanceOf(typeof(User), contentResult.Content);
        }

        [Test]
        public void Get_ById_FoundId2()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            
            // Act
            IHttpActionResult result = controller.Get(2);
            var contentResult = result as OkNegotiatedContentResult<User>;

            // Assert
            Assert.NotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Id);
        }

        [Test]
        public void Post_ValidRequestData_ReturnId()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var newUser = new User { Id = 3, Name = "Test", Points = 3 };

            // Act
            IHttpActionResult result = controller.Post(newUser);
            var contentResult = result as OkNegotiatedContentResult<int>;

            // Assert
            Assert.AreEqual(newUser.Id, contentResult.Content);
        }


        /// <summary>
        ///     will pass only if makes some changes in the model like making "Name" property as required field
        /// </summary>
        [Test]
        public void Post_InvalidRequestData_ReturnBadRequestType()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            var newUser = new User { Id = 3, Name="Test", Points = 3 };

            // Act
            IHttpActionResult result = controller.Post(null); //newUser as parameter will make test fail
            var contentResult = result as InvalidModelStateResult;

            // Assert
            Assert.IsInstanceOf<InvalidModelStateResult>(contentResult);
        }

        [Test]       
        public void Put_ValidRequestData_ReturnSuccessMessage()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var existingUser = new User { Id = 2, Name = "Test", Points = 5 };

            // Act
            IHttpActionResult result = controller.Put(existingUser);
            var contentResult = result as OkNegotiatedContentResult<string>;

            // Assert
            Assert.AreEqual("Success", contentResult.Content);
        }

        [Test]
        public void Put_ValidRequestData_ReturnNotFoundType()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var existingUser = new User { Id = -1, Name = "Test", Points = 5 };

            // Act
            IHttpActionResult result = controller.Put(existingUser);
            var contentResult = result as NotFoundResult;

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(contentResult);
        }


        /// <summary>
        ///     will pass only if makes some changes in the model like making "Name" property as required field
        /// </summary>
        [Test]
        public void Put_InvalidRequestData_ReturnBadRequestType()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            IHttpActionResult result = controller.Put(null);
            var contentResult = result as InvalidModelStateResult;

            // Assert
            Assert.IsInstanceOf<InvalidModelStateResult>(contentResult);
        }
    }
}
