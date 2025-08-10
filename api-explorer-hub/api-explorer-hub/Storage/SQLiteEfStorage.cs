using api_explorer_hub.DataContext;
using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using System.Net.WebSockets;

namespace api_explorer_hub.Storage
{
    public class SQLiteEfStorage : IStorage
    {
        protected readonly SqliteDbContext context;

        public SQLiteEfStorage(SqliteDbContext context)
        {
            this.context = context;           
        }

        public List<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public Contact Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return contact;
        }

        public bool Remove(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }

            context.Contacts.Remove(contact);
            context.SaveChanges();
            return true;
        }

        public bool Update(ContactDto contactDto, int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return false;
            }

            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            contact.Phone = contactDto.Phone;
            contact.Address = contactDto.Address;

            context.SaveChanges();
            return true;
        }
    }
}
