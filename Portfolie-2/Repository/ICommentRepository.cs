using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll(int limit = 10, int offset = 0);
        Comment GetById(int id);
    }
}