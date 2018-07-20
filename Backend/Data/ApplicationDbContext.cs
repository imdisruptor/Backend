using Backend.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Catalog>()
                .HasMany(c => c.Messages)
                .WithOne(p => p.Catalog)
                .HasForeignKey(k => k.CatalogId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Catalog>()
                .HasMany(c => c.ChildCatalogs)
                .WithOne(c => c.ParentCatalog)
                .HasForeignKey(c => c.ParentCatalogId);

            base.OnModelCreating(builder);
        }
    }
    //class VladAgressorInitilizer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
}
