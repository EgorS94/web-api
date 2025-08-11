using api_explorer_hub.Model;

namespace api_explorer_hub.Storage
{
    public interface IPaginationStorage : IStorage
    {
        Contact FindContactById(int id);

        (List<Contact>, int TotalCount) GetContacts(int pageNumber,  int pageSize);
    }
}
