using api_explorer_hub.Model;
using Bogus;
using Microsoft.Data.Sqlite;

namespace api_explorer_hub.Seed
{
    public class FakerInitializer : IInitializer
    {
        private readonly string connectionString;

        public FakerInitializer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Initialize()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS contacts(
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                email TEXT NOT NULL,
                phone_number TEXT NOT NULL,
                address TEXT NOT NULL
            );";

            command.ExecuteNonQuery();

            command.CommandText = @"SELECT count(*) FROM contacts";

            long count = (long)command.ExecuteScalar();

            if (count == 0)
            {
                var faker = new Faker<Contact>("ja")
                    .RuleFor(c => c.Name, f=>f.Name.FullName())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress());

                var contacts = faker.Generate(20);

                foreach (var item in contacts)
                {
                    command.CommandText = @"INSERT INTO contacts
                        (name, email, phone_number, address)
                        VALUES 
                        (@name, @email, @phone, @address);";

                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@name", item.Name);
                    command.Parameters.AddWithValue("@email", item.Email);
                    command.Parameters.AddWithValue("@phone", item.Phone);
                    command.Parameters.AddWithValue("@address", item.Address);

                    command.ExecuteNonQuery();
                }


            }
        }
    }
}
