using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using XYZCorp.Core.Domain;
using XYZCorp.Core.Repositories;
using XYZCorp.WebApi.Controllers;

/// <summary>
/// Developer: Peter Gil O. Villar
/// </summary>
namespace XYZCorp.WebApi.Tests.Controllers
{
    [TestFixture]
    public class ValuesControllerTest
    {

        private Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();
        private ValuesController _controllerInstance;

        private List<User> _mockData = new List<User>();

        public ValuesControllerTest()
        {
            _mockUserRepository.Setup(m => m.GetAllAsync());
            _controllerInstance = new ValuesController(_mockUserRepository.Object);

            _mockData.AddRange(new User[] {
                    new User { Id = 1, Name="Peter", Points = 1 },
                    new User { Id = 2, Name="Jonh", Points = 2 }
                });
        }

        [Test]
        public async Task Get_ReturnType_ListOfUser()
        {
            //// Arrange
            //var mockUserRepository = new Mock<IUserRepository>();
            //mockUserRepository.Setup(m => m.GetAllAsync());
            //var controller = new ValuesController(mockUserRepository.Object);
            //// Act
            //IHttpActionResult result = await controller.Get();
            //var contentResult = result as OkNegotiatedContentResult<List<User>>;

            //// Assert
            //Assert.IsInstanceOf<List<User>>(contentResult.Content);

            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var users = _mockData;                

                mock.Mock<IValuesController>().Setup((m) => m.Get())
                    .ReturnsAsync(new OkNegotiatedContentResult<List<User>>(
                        users, _controllerInstance)
                    );

                var controller = mock.Create<IValuesController>();

                //Act
                IHttpActionResult result = await controller.Get();
                var contentResult = result as OkNegotiatedContentResult<List<User>>;

                //Assert
                Assert.IsInstanceOf<List<User>>(contentResult.Content);
            }
        }

        [Test]
        public async Task Get_ReturnCount_Two()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var users = _mockData;

                mock.Mock<IValuesController>().Setup((m) => m.Get())
                    .ReturnsAsync(new OkNegotiatedContentResult<List<User>>(
                        users, _controllerInstance)
                    );

                var controller = mock.Create<IValuesController>();

                //Act
                IHttpActionResult result = await controller.Get();
                var contentResult = result as OkNegotiatedContentResult<List<User>>;

                //Assert
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(2, contentResult.Content.Count);
            }
        }

        [Test]
        public async Task Get_ById_NotFoundType()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                mock.Mock<IValuesController>().Setup((m) => m.Get(-1))
                    .ReturnsAsync(new NotFoundResult(
                        _controllerInstance)
                    );

                var controller = mock.Create<IValuesController>();

                //Act
                IHttpActionResult result = await controller.Get(-1);
                var contentResult = result as NotFoundResult;

                // Assert
                Assert.IsInstanceOf(typeof(NotFoundResult), contentResult);
            }
        }

        [Test]
        public async Task Get_ById_FoundTypeOfUser()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var user = _mockData.Find(x => x.Id == 2);
                mock.Mock<IValuesController>().Setup((m) => m.Get(2))
                    .ReturnsAsync(new OkNegotiatedContentResult<User>(
                        user, _controllerInstance)
                    );

                var controller = mock.Create<IValuesController>();

                //Act
                IHttpActionResult result = await controller.Get(2);
                var contentResult = result as OkNegotiatedContentResult<User>;

                // Assert
                Assert.IsInstanceOf(typeof(User), contentResult.Content);
            }
        }


        [Test]
        public void Get_ById_FoundId2()
        {
            //TODO
            Assert.Pass();
        }

        [Test]
        public void Post_ValidRequestData_ReturnId()
        {
            //TODO
            Assert.Pass();
        }


        /// <summary>
        ///     will pass only if makes some changes in the model like making "Name" property as required field
        /// </summary>
        [Test]
        public void Post_InvalidRequestData_ReturnBadRequestType()
        {
            //TODO
            Assert.Pass();
        }

        [Test]
        public void Put_ValidRequestData_ReturnSuccessMessage()
        {
            //TODO
            Assert.Pass();
        }

        [Test]
        public void Put_ValidRequestData_ReturnNotFoundType()
        {

        }


        /// <summary>
        ///     will pass only if makes some changes in the model like making "Name" property as required field
        /// </summary>
        [Test]
        public void Put_InvalidRequestData_ReturnBadRequestType()
        {
            //TODO
            Assert.Pass();
        }
    }
}
