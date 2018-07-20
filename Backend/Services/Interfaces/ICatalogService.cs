using System;

public class ICatalogService
{
	public ICatalogService()
	{
        IdList GetCatalogs(string ownerId);
        IdList GetMessages(string ownerId);
        Task DeleteCatalog(string id);
        void DeleteMessage(string id);
        void CreateCatalog(string ownerId, string name);
        void CreateMessage(string ownerId, string name, string text);
	}
}
