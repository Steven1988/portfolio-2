using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public interface ISearchHistoryRepository
    {
        IEnumerable<SearchHistory> GetByUserId(int UserId, int limit = 10, int offset = 0);
        void DeleteAllByUserId(int UserId);
    }
}