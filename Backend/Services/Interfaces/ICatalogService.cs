using Backend.Models;
using Backend.Models.Entities;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ICatalogService
    {
        Task EditCatalogAsync(Catalog catalog);
        Catalog FindCatalogId(string id);
        void DeleteCatalog(string id);
        void DeleteMessage(string id);
        Task CreateCatalogAsync(Catalog catalog);
        void CreateMessage(string ownerId, string name, string text);
    }
}