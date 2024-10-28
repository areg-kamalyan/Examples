using Api.Models;

namespace Api
{
    public interface ISmartPhone
    {
        Task<List<Phone>?> ListOFAllObjects();
        Task<List<Phone>?> ListOfObjectsByIds(IEnumerable<string> Ids);
        Task<Phone?> SingleObject(string Id);
        Task<Phone?> AddObject(Phone phone);
        Task<Phone?> UpdateObject(Phone phone);
        Task<Dictionary<string, string>?> DeleteObject(string Id);
    }
}
