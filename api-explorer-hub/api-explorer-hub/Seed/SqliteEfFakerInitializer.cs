using api_explorer_hub.DataContext;
using api_explorer_hub.Model;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace api_explorer_hub.Seed
{
    public class SqliteEfFakerInitializer : IInitializer
    {
        private readonly SqliteDbContext context;

        public SqliteEfFakerInitializer(SqliteDbContext context)
        {
            this.context = context;
        }

        private string GenerateEmailForPerson(string name)
        {
            string email = TransLiterate(name)
                .ToLower()
                .Replace(" ", ".") + "@example.com";

            return email;
        }

        private string TransLiterate(string name)
        {
            Dictionary<char, string> transLitTable = new Dictionary<char, string>
            {
                {'а',"a"},{'б',"b"},{'в',"v"},{'г',"g"},{'д',"d"},{'е',"e"},{'ё',"yo"},{'ж',"zh"},{'з',"z"},{'и',"i"},{'й',"y"},
                {'к',"k"},{'л',"l"},{'м',"m"},{'н',"n"},{'о',"o"},{'п',"p"},{'р',"r"},{'с',"s"},{'т',"t"},{'у',"u"},{'ф',"f"},
                {'х',"h"},{'ц',"ts"},{'ч',"ch"},{'ш',"sh"},{'щ',"shch"},{'ъ',""},{'ы',"y"},{'ь',""},{'э',"e"},{'ю',"yu"},{'я',"ya"}
            };

            var result = "";

            foreach (var ch in name.ToLower())
            {
                if (transLitTable.ContainsKey(ch))
                    result += transLitTable[ch];
                else
                    result += ch;
            }

            return result;
        }
        
        public void Initialize()
        {
            context.Database.Migrate();

            if (!context.Contacts.Any())
            {
                var faker = new Faker<Contact>("ru")
                    .RuleFor(c => c.Name, f => f.Name.FullName())
                    .RuleFor(c => c.Email, (f, c) => GenerateEmailForPerson(c.Name))
                    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress());

                var contacts = faker.Generate(20);

                context.Contacts.AddRange(contacts);
                context.SaveChanges();
            }
        }
    }
}
