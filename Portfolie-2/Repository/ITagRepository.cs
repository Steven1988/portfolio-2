using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll(int limit = 10, int offset = 0);
        Tag GetById(int id);
    }
}