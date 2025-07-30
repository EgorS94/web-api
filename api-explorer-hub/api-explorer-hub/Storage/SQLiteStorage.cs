using api_explorer_hub.Dto;
using api_explorer_hub.Model;

namespace api_explorer_hub.Storage
{
    public class SQLiteStorage : IStorage
    {
        public bool Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact FindContactById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ContactDto contactDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
