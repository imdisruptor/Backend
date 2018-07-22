using Backend.Data;
using Backend.Exceptions;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;

        public CatalogService(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public IdList GetCatalogs(string ownerId)
        {
            IdList result = new IdList();
            return result;
        }

        public IdList GetMessages(string ownerId)
        {
            IdList result = new IdList();
            
            return result;
        }*/

        public void DeleteCatalog(string id)
        {
            /*
             * рекурсивно удалять всех сынков и вложенные документы
             */
        }

        public void DeleteMessage(string id)
        {

        }

        public Catalog FindCatalogId(string id)
        {
            var catalog = _context.Catalogs.Find(id);

            if (catalog == null)
            {
                throw new NotFoundException();
            }

            return catalog;
        }

        public async Task CreateCatalogAsync(Catalog catalog)
        {
            _context.Add(catalog);
            await _context.SaveChangesAsync();
        }
        public async Task EditCatalogAsync(string catalogId, Catalog catalog)
        {
            var oldCatalog = _context.Catalogs.Find(catalogId);
            if(oldCatalog==null)
            {
                throw new NotFoundException();
            }
            if (!string.IsNullOrWhiteSpace(catalog.Title)) 
            {
                oldCatalog.Title = catalog.Title;
            }
            //Изменение родительского каталога
            //if (!catalog.ParentCatalogId.Equals(oldCatalog.ParentCatalogId) && !string.IsNullOrWhiteSpace(catalog.Title))
            //{
            //    oldCatalog.Title = catalog.Title;
            //}
            await _context.SaveChangesAsync();
        }

        public void CreateMessage(string ownerId, string name, string text)
        {

        }
    }
}