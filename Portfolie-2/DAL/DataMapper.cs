using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Portfolie_2.Repository;

namespace Portfolie_2.DAL
{
    public interface IDataMapper<T> where T : class, IIdentityField
    {
        string TableName { get; }      
        /// The attributes to be mapped from the database entity, except
        /// the Id that is always assumed pressent.
        string[] Attributes { get; }

        /// Find one specific entity identifyed by the id.
        /// <param name="id">The Id of the database entity to be found</param>
        /// <returns>The domain object</returns>
        T Find(long id);

        /// The is the method that do the actually mapping from a database reader to a domain object.
        /// <param name="reader">The reader pointing to the position just before the object to fetch</param>
        /// <returns>The domain object</returns>
        //T Map(MySqlDataReader reader);

        /// Execute a general database query, given a SqlCommand
        /// <param name="command">The MySqlCommand to execute</param>
        //IEnumerable<T> Query(MySqlCommand command);
    }


    public abstract class DataMapper<T> : IDataMapper<T> where T : class, IIdentityField
    {
        // The name of the table to be mapped
        public string TableName { get; set; }

        // The attributes to be mapped from the database entity, except
        // the Id that is always assumed pressent.
        public string[] Attributes { get; set; }


        public virtual T Find(long id)
        {
            var sql = string.Format("select {0} from {1}", Attributes, TableName);

            using (var dbconnect = new MySqlConnection(ConnectionString.String))
            {
                dbconnect.Open();
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection = dbconnect;
                    using (var reader = cmd.ExecuteReader())
                    {
                        return Map(reader);
                    }
                }
            }
        }
    }
}