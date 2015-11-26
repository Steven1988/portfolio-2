using MySql.Data.MySqlClient;
using Portfolie_2.DataMapper;
using Portfolie_2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolie_2.Repository
{
    public class TagRepository : ITagRepository
    {
        private TagMapper _mapper;

        public TagRepository(TagMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<Tag> GetAll(int limit = 10, int offset = 0)
        {
            return _mapper.GetAll(limit, offset);
        }

        public Tag GetById(int id)
        {
            return _mapper.GetById(id);
        }
    }
}