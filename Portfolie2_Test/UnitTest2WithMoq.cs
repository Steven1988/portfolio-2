﻿using System.Linq;
using NUnit.Framework;
using Moq;
using Portfolie_2.Models;
using Portfolie_2.Repository;
using Portfolie_2.Controllers;
using System.Web.Http;

namespace Portfolie2_Test
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestFixture]
    public class UnitTest2WithMoq
    {
        [Test]
        public void TestPostRepo() 
        {
            //Mock user object
            var moqPost = new Mock<DetailPost>();
            //Arrange
            var postRepoTest = new PostRepository(new Portfolie_2.DataMapper.FavoriteMapper());

            //Act
            int postId = 45325;
            int userId = 2975;
            var getPostById = postRepoTest.GetById(postId, userId, 10, 0);

            //Assert
            Assert.That(getPostById,Is.EqualTo(45325), "It's not as expected");
        }


    }
}
