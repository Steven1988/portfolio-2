using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class SearchHistoryRepository : ISearchHistoryRepository
    {
        public IEnumerable<SearchHistory> GetByUserId(int UserId, int limit = 10, int offset = 0)
        {
            return null;
        }


        public void DeleteAllUserId(int userId)
        {
            
        }

    }
}