using api_explorer_hub.Dto;
using api_explorer_hub.Model;
using Bogus;
using Bogus.DataSets;

namespace api_explorer_hub.Storage
{
    public class ContactStorage
    {
        private List<Contact> Contacts { get; set; }
        
        public ContactStorage()
        {
            this.Contacts = new List<Contact>();
            var faker = new Faker("ja");
            for (int i = 0; i <= 10; i++)
            {
                this.Contacts.Add(new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Name.FullName(),
                    Email = faker.Internet.Email(),
                    Phone = faker.Phone.PhoneNumber(),
                    Address = faker.Address.StreetAddress()
                });
            }
        }


        public List<Contact> GetContacts()
        {
            return this.Contacts;
        }

        public bool Add(Contact contact)
        {
            foreach (var item in Contacts)
            {
                if (item.Id.Equals(contact.Id))
                {
                    return false;
                }
            }
            this.Contacts.Add(contact);
            return true;
        }

        public bool Remove(Guid id)
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

        public bool Update(ContactDto contactDto, Guid id)
        {
            Contact contact;
            for (int i = 0; i < this.Contacts.Count; i++)
            {
                if (this.Contacts[i].Id.Equals(id))
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

        public Contact FindContactById(Guid id)
        {
            
            foreach (var item in Contacts)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return NullContact();
        }

        public Contact NullContact()
        {
            Contact nullContact  = new Contact{
                Id = Guid.Empty,
                Name = "",
                Email = "",
                Phone = "",
                Address = ""
            };

            return nullContact;
        }
    }
}
