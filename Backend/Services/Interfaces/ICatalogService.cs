using Backend.Models;
using Backend.Models.Entities;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ICatalogService
    {
        Task EditCatalogAsync(string catalogId, Catalog catalog);
        Catalog FindCatalogId(string id);
        void DeleteCatalog(string id);
        void DeleteMessage(string id);
        Task CreateCatalogAsync(Catalog catalog);
        Task CreateMessage(string catalogId, Message message);
    }
}