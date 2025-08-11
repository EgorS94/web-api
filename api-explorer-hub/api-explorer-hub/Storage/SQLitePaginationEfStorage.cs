using api_explorer_hub.DataContext;
using api_explorer_hub.Model;

namespace api_explorer_hub.Storage
{
    public class SQLitePaginationEfStorage : SQLiteEfStorage, IPaginationStorage
    {
        public SQLitePaginationEfStorage(SqliteDbContext context)
            :base(context)
        {
            
        }

        public Contact FindContactById(int id)
        {
            return base.context.Contacts.Find(id);
        }

        public (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize)
        {
            int total = base.context.Contacts.Count();
            List<Contact> contacts = base.context.Contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (contacts,  total);
        }
    }
}
