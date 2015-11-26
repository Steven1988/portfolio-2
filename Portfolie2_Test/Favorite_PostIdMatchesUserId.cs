using System.Linq;
using NUnit.Framework;
using Moq;
using Portfolie_2.Models;
using Portfolie_2.Repository;
using Portfolie_2.Controllers;
using System.Web.Http;
using Portfolie_2.DataMapper;

namespace Portfolie2_Test
{
    /// <summary>
    /// Test whether ID of user is in agreement with DisplayName of user
    /// </summary>
    [TestFixture]
    public class Favorite_PostIdMatchesUserId
    {
        private int postId = 124462;
        private int userId = 246;

        [Test]
        public void TestPostRepo()
        {
            //Arrange
            var postRepoTest = new FavoriteMapper();

            //Act
            var favorite = postRepoTest.GetById(postId, userId);

            //Assert
            Assert.That(favorite.PostId,Is.EqualTo(124462), "ID");
            Assert.That(favorite.UserId,Is.EqualTo(246), "UserID");
        }


    }
}
