using FailApp.Data;
using FailApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FailApp.Services
{
    public class ItemService : CRUDService<long, Item>
    {
        private Context context;

        public ItemService(Context context)
        {
            this.context = context;
        }

        public void Delete(Item e)
        {
            string query = @$"DELETE FROM Items WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(long key)
        {
            string query = @$"DELETE FROM Items WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public IEnumerable<Item> Get()
        {
            string query = @$"SELECT Id, Name, Description, Price FROM Items";
            List<Item> items = new List<Item>();
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                items.Add(new Item()
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Description = sqlDataReader.GetString(2),
                    Price = sqlDataReader.GetDecimal(3)
                });
            }
            conn.Close();
            return items;
        }

        public Item Get(long key)
        {
            string query = @$"SELECT Id, Name, Description, Price FROM Items WHERE Id = {key}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();
            var item = new Item()
            {
                Id = sqlDataReader.GetInt32(0),
                Name = sqlDataReader.GetString(1),
                Description = sqlDataReader.GetString(2),
                Price = sqlDataReader.GetDecimal(3)
            };
            conn.Close();
            return item;
        }

        public void Save(Item e)
        {
            string query = @$"INSERT INTO Items (Id, Name, Description, Price) VALUES({e.Id}, {e.Name}, {e.Description}, {e.Price})";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Item e)
        {
            string query = @$"UPDATE Items Name = {e.Name}, Description = {e.Description}, Price = {e.Price} WHERE Id = {e.Id}";
            using SqlConnection conn = context.GetConnection();
            conn.Open();
            using SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
