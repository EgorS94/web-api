using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using Bogus;
using Bogus.DataSets;

namespace api_explorer_hub.Storage
{
    public class InMemoryStorage : IStorage
    {
        private List<Contact> Contacts { get; set; }

        public InMemoryStorage()
        {
            this.Contacts = new List<Contact>();
            var faker = new Faker("ru");
            for (int i = 0; i <= 10; i++)
            {
                this.Contacts.Add(new Contact
                {
                    Id = i + 1,
                    Name = faker.Name.FullName(),
                    Email = faker.Internet.Email(),
                    Phone = faker.Phone.PhoneNumber("###-####-####"),
                    Address = faker.Address.StreetAddress()
                });
            }
        }


        public List<Contact> GetContacts()
        {
            return this.Contacts;
        }

        public Contact Add(Contact contact)
        {
            foreach (var item in Contacts)
            {
                if (item.Id == contact.Id)
                {
                    return null;
                }
            }
            this.Contacts.Add(contact);
            return contact;
        }

        public bool Remove(int id)
        {
            Contact contact;
            for (int i = 0; i < this.Contacts.Count; i++)
            {
                if (this.Contacts[i].Id == id)
                {
                    contact = this.Contacts[i];
                    Contacts.Remove(contact);
                    return true;
                }
            }
            return false;
        }

        public bool Update(ContactDto contactDto, int id)
        {
            Contact contact;
            for (int i = 0; i < this.Contacts.Count; i++)
            {
                if (this.Contacts[i].Id == id)
                {
                    contact = this.Contacts[i];
                    contact.Name = contactDto.Name;
                    contact.Email = contactDto.Email;
                    contact.Phone = contactDto.Phone;
                    contact.Address = contactDto.Address;
                    return true;
                }
            }
            return false;
        }

        //public Contact FindContactById(int id)
        //{
        //    foreach (var item in Contacts)
        //    {
        //        if (item.Id == id) return item;
        //    }
        //    return null;
        //}
    }
}
