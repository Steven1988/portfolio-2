using System.Linq;
using NUnit.Framework;
using Moq;
using Portfolie_2.Models;
using Portfolie_2.Repository;
using Portfolie_2.Controllers;
using System.Web.Http;



namespace Portfolie2_Test
{
    //class FakeRepo : UserRepository
    //{
    //    public User GetUserById(int id)
    //    {
    //        return new User { DisplayName = "Peter", Age = 22 };
    //    }
    //}

    public class ControllerTests
    {
        [Test]
        public void GetPerson_ValidId_ReturnsPersonAsJson()
        {
            //Arrange
            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(new User { DisplayName = "Peter", Age = 22 });
            //repoMock.Setup(m => m.Something).Returns(5);
            var controller = new UserController(repoMock.Object);

            //Act
            var result = controller.GetUser(1);

            //Assert
            Assert.AreEqual("{\"DisplayName\":\"Peter\",\"Age\":22}", result);
        }
    }

    
}
