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
    }
}
