using System;

public class CatalogService : ICatalogService
{
    private readonly string _curentCatalog;
    private readonly ApplicationDbContext _context;

    public CatalogService(string curentCatalog, ApplicationDbContext context)
	{
        _context = context;
        _curentCatalog = curentCatalog;
	}

    public IdList GetCatalogs(string ownerId)
    {
        IdList result;
        /*
        
        */
        return result;
    }

    public IdList GetMessages(string ownerId)
    {
        IdList result;
        /*
        
        */
        return result;
    }

    public async Task DeleteCatalog(string id)
    {
        /*
         * рекурсивно удалять всех сынков и вложенные документы
         */
    }

    void DeleteMessage(string id)
    {

    }

    void CreateCatalog(string ownerId, string name)
    {

    }

    void CreateMessage(string ownerId, string name, string text)
    {

    }
}
