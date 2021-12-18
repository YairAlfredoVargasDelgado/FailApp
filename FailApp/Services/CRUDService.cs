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

        public abstract TEntity Map(SqlDataReader sqlDataReader);
        public abstract string Values(TEntity entity);

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
            string query = @$"INSERT INTO {name} ({string.Join(",", attributes)}) VALUES({Values(entity)})";
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
            //string query = @$"UPDATE {name} Name = {e.Name}, Description = {e.Description}, Price = {e.Price} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand("", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
