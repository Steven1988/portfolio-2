using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll(int limit = 10, int offset = 0);
        string commentsql(int postId);
        IEnumerable<DetailPost> GetById(int id);
        IEnumerable<SearchPost> GetAllSearch(string searchString);
    }
}