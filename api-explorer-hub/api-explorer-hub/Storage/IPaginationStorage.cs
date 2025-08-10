using api_explorer_hub.Model;

namespace api_explorer_hub.Storage
{
    public interface IPaginationStorage : IStorage
    {
        Contact FindContactById(int id);
    }
}
