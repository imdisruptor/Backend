using Backend.Data;
using Backend.Exceptions;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using System;
using System.Linq;
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

        public void DeleteCatalog(string id)
        {
            /*
             * рекурсивно удалять всех сынков и вложенные документы
             */
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
            if(!string.IsNullOrWhiteSpace(catalog.ParentCatalogId))
            {
                var newCatalog = _context.Catalogs.Find(catalog.ParentCatalogId);
                if (newCatalog == null)
                {
                    throw new NotFoundException();
                }
                oldCatalog.ParentCatalog = newCatalog;
            }
            await _context.SaveChangesAsync();
        }

        public async Task CreateMessage( Message message)
        {
            var catalog = _context.Catalogs.Find(message.CatalogId);
            if(catalog == null)
            {
                throw new NotFoundException();
            }
            message.CreatedAt = DateTime.Now;
            catalog.Messages.Add(message);
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

        }
        public async Task EditMessage(string messageId,Message message)
        {
            if (string.IsNullOrEmpty(messageId))
                throw new NotFoundException();

            var oldMessage = _context.Messages.Find(messageId);

            if(oldMessage == null)
            {
                throw new NotFoundException();
            }

            var catalog = _context.Catalogs.Find(message.CatalogId);
            if(catalog != null)
            {
                oldMessage.Catalog = catalog;
                oldMessage.CatalogId = catalog.Id;
            }

            if(!string.IsNullOrWhiteSpace(message.Subject))
            {
                oldMessage.Subject = message.Subject;
            }

            if(!string.IsNullOrWhiteSpace(message.Text))
            {
                oldMessage.Text = message.Text;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessage(string id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);

            if (message == null)
            {
                throw new NotFoundException();
            }

            _context.Messages.Remove(message);

            await _context.SaveChangesAsync();

        }
    }
}