using System.Linq;
using NUnit.Framework;
using Moq;
using Portfolie_2.Models;
using Portfolie_2.Repository;
using Portfolie_2.Controllers;
using System.Web.Http;

namespace Portfolie2_Test
{
    /// <summary>
    /// Test whether ID of user is in agreement with DisplayName of user
    /// </summary>
    [TestFixture]
    public class UserIdMatchesDisplayName
    {
        [Test]
        public void TestUserRepo()
        {
            //Arrange
            var userRepoTest = new UserRepository();

            //Act
            var user = userRepoTest.GetById(4);

            //Assert
            Assert.That(user.Id,Is.EqualTo(4), "ID");
            Assert.That(user.DisplayName,Is.EqualTo("Joel Spolsky"), "Name");
        }


    }
}
