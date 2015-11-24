using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface ITiRepository
    {
        IEnumerable<Ti> GetAll(int limit = 10, int offset = 0);
        Ti GetByTid(int tid);
    }
}