using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface IPostRepository
    {

        IEnumerable<SearchPost> GetAll(int limit = 10, int offset = 0);
        IEnumerable<DetailPost> GetById(int id, int userId, int limit, int offset);
        IEnumerable<SearchPost> GetSearch(string searchString, int userId, int limit, int offset);
    }
}