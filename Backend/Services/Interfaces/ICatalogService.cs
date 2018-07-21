using Backend.Models;

namespace Backend.Services.Interfaces
{
    public interface ICatalogService
    {
        IdList GetCatalogs(string ownerId);
        IdList GetMessages(string ownerId);
        void DeleteCatalog(string id);
        void DeleteMessage(string id);
        void CreateCatalog(string ownerId, string name);
        void CreateMessage(string ownerId, string name, string text);
    }
}