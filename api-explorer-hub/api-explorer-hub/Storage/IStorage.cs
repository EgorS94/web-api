using api_explorer_hub.Dto;
using api_explorer_hub.Model;

namespace api_explorer_hub.Storage
{
    public interface IStorage
    {
        List<Contact> GetContacts();

        Contact Add(Contact contact);

        bool Remove(int id);

        bool Update(ContactDto contactDto, int id);

        //Contact FindContactById(int id);

    }
}
