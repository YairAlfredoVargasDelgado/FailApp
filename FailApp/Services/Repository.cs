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
    public abstract class Repository<TKey, TEntity> where TEntity : Entity<TKey>
    {
        protected Context context;
        protected string name = typeof(TEntity).Name;
        protected List<string> exclude = new List<string>();
        protected string[] attributes = typeof(TEntity).GetProperties()
            .Where(prop => !Attribute.IsDefined(prop, typeof(Ignore)))
            .Select(prop => prop.Name)
            .ToArray();

        public Repository(Context context)
        {
            this.context = context;
        }

        public virtual string[] Values(object src)
        {
            List<string> values = new List<string>();
            foreach(var attr in attributes)
            {
                if (attr != "Id")
                    values.Add(typeof(TEntity).GetProperty(attr).GetValue(src, null).ToString());
            }
            return values.Select(v => v.GetType() == typeof(string) ? $"'{v}'" : v).ToArray();
        }

        public abstract TEntity Map(SqlDataReader sqlDataReader);

        public virtual IEnumerable<TEntity> Get()
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

        public virtual TEntity Get(TKey key)
        {
            string query = @$"SELECT {string.Join(",", attributes)} FROM {name} WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();
            return Map(sqlDataReader);
        }

        public virtual void Save(TEntity entity)
        {
            string query = @$"INSERT INTO {name} ({string.Join(",", attributes.ToList().Where(att => att != "Id").ToArray())}) VALUES({string.Join(",", Values(entity))})";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public virtual void Delete(TEntity e)
        {
            string query = @$"DELETE FROM {typeof(TEntity)} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public virtual void Delete(TKey key)
        {
            string query = @$"DELETE FROM {name} WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public virtual void Update(TEntity e)
        {
            var values = Values(e);
            var _attrs = attributes.ToList().Where(v => v != "Id").ToArray();
            string s = _attrs[0] + " = " + values[0];
            for (int i = 1; i < _attrs.Length; i++)
            {
                s += "," + _attrs[i] + " = " + values[i];
            }
            string query = @$"UPDATE {name} SET {s} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
