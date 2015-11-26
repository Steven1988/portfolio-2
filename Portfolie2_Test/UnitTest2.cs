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
    public class UnitTest2
    {
        [Test]
        public void TestPostRepo()
        {
            //Arrange
            var postRepoTest = new PostRepository();

            //Act
            //var contains = pfDetails.GetPfEmployerControlSoFar(1);
            int postId = 45325;
            int userId = 2975;
            var getPostById = postRepoTest.GetById(postId, userId);

            //Assert
            Assert.That(getPostById,Is.EqualTo(45325), "It's not as expected");
        }


    }
}
