using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    Initializer.Initialize(userManager, roleManager).Wait();
                }
                catch (Exception) { }

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    SampleData.Initialize(context).Wait();
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "ERror pri initialization DATABASE Eeeee");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
    //Shit Code. Delete 
    public static class SampleData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (!context.Messages.Any() && !context.Catalogs.Any())
            {
                //Catalog catalog = new Catalog
                //{
                //    Title = "Second catalog",
                //    Messages = new List<Message>(),
                //    ChildCatalogs = new List<Catalog>()
                //};
                //context.Catalogs.Add(catalog);

                //context.Messages.Add(new Message
                //{
                //    Catalog = catalog,
                //    CatalogId = catalog.Id,
                //    DateTime = DateTime.Now,
                //    Text = "kdfjx;lxkdjf;lxkjdf;lj",
                //    Subject = "Education"
                //});
                //context.Messages.Add(new Message
                //{
                //    Catalog = catalog,
                //    CatalogId = catalog.Id,
                //    DateTime = DateTime.Now,
                //    Text = "Moscow is the capital of R",
                //    Subject = "Education"
                //});
                //context.Messages.Add(new Message
                //{
                //    Catalog = catalog,
                //    CatalogId = catalog.Id,
                //    DateTime = DateTime.Now,
                //    Text = "How do.....",
                //    Subject = "Education"
                //});
                //context.Messages.Add(new Message
                //{
                //    Catalog = catalog,
                //    CatalogId = catalog.Id,
                //    DateTime = DateTime.Now,
                //    Text = "TExttttttttttttt",
                //    Subject = "Subject"
                //});
                //context.Messages.Add(new Message
                //{
                //    Catalog = catalog,
                //    CatalogId = catalog.Id,
                //    DateTime = DateTime.Now,
                //    Text = "asdasdadasdasdadasdasdasd",
                //    Subject = "Sibject"
                //});
                await context.SaveChangesAsync();
            }
            
        }
    }
}
