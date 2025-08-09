using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using Microsoft.Data.Sqlite;
using System.Text;

namespace api_explorer_hub.Storage
{
    public class SQLiteStorage : IStorage
    {
        private readonly string connectionString;

        public SQLiteStorage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Contact Add(Contact contact)
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            string sql = @"INSERT INTO contacts (name, email, phone_number, address) VALUES (@name, @email, @phone, @address);
                            SELECT last_insert_rowid();
            ";
            //string sql = new StringBuilder()
            //    .Append("INSERT INTO contacts (name, email, phone_number, address) VALUES")
            //    .Append($"('{contact.Name}', '{contact.Email}', '{contact.Phone}', '{contact.Address}');").ToString();
            command.CommandText = sql;

            //command.Parameters.AddWithValue("@id", contact.Id);
            command.Parameters.AddWithValue("@name", contact.Name);
            command.Parameters.AddWithValue("@email", contact.Email);
            command.Parameters.AddWithValue("@phone", contact.Phone);
            command.Parameters.AddWithValue("@address", contact.Address);

            contact.Id = Convert.ToInt32(command.ExecuteScalar());

            return contact;
        }

        //public Contact FindContactById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Contact> GetContacts()
        {
            var contact = new List<Contact>();

            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM contacts";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                contact.Add(new Contact()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Address = reader.GetString(4)
                });
            }

            return contact;
        }

        public bool Remove(int id)
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            string sql = "DELETE FROM contacts WHERE id = @id";

            command.CommandText = sql;

            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Update(ContactDto contactDto, int id)
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            string sql = "UPDATE contacts SET name = @name, " +
                "email = @email, phone_number = @phone, address = @address " +
                "WHERE id = @id";

            command.CommandText = sql;

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", contactDto.Name);
            command.Parameters.AddWithValue("@email", contactDto.Email);
            command.Parameters.AddWithValue("@phone", contactDto.Phone);
            command.Parameters.AddWithValue("@address", contactDto.Address);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
