using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public abstract class CRUDService<TKey, TEntity> where TEntity : Entity<TKey>
    {
        private Context context;
        private string name = typeof(TEntity).Name;
        private string[] attributes = typeof(TEntity).GetProperties().Select(prop => prop.Name).ToArray();

        public CRUDService(Context context)
        {
            this.context = context;
        }

        public string[] Values(object src)
        {
            List<string> values = new List<string>();
            foreach(var attr in attributes)
            {
                values.Add(typeof(TEntity).GetProperty(attr).GetValue(src, null).ToString());
            }
            return values.ToArray();
        }

        public abstract TEntity Map(SqlDataReader sqlDataReader);

        public IEnumerable<TEntity> Get()
        {
            string query = @$"SELECT {string.Join(",", attributes)} FROM {name}";
            List<TEntity> entities = new List<TEntity>();
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                entities.Add(Map(sqlDataReader));
            }
            conn.Close();
            return entities;
        }

        public TEntity Get(TKey key)
        {
            string query = @$"SELECT {string.Join(",", attributes)} FROM {name} WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();
            return Map(sqlDataReader);
        }

        public void Save(TEntity entity)
        {
            string query = @$"INSERT INTO {name} ({string.Join(",", attributes)}) VALUES({string.Join(",", Values(entity))})";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(TEntity e)
        {
            string query = @$"DELETE FROM {typeof(TEntity)} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(TKey key)
        {
            string query = @$"DELETE FROM {name} WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(TEntity e)
        {
            var values = Values(e);
            string s = attributes[0] + " = " + values[0] + ",";
            for (int i = 1; i < attributes.Length; i++)
            {
                s += attributes[i] + " = " + values[i];
            }
            string query = @$"UPDATE {name} SET {s} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand("", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
