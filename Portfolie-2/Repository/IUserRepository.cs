using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface IUserRepository
    {
        int Something { get; set; }

        /// <summary>
        /// selects all data from first 10 users
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        IEnumerable<User> GetAll(int limit = 10, int offset = 0);

        /// <summary>
        /// selects data from user with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);
    }
}