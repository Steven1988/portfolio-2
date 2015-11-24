using System.Collections.Generic;
using Portfolie_2.Models;

namespace Portfolie_2.Repository
{
    public interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetAll(int limit = 10, int offset = 0);
        Favorite GetByUserId(int userId, int postId);
    }
}