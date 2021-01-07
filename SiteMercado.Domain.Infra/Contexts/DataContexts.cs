using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SiteMercado.Domain.Entities;

namespace CursoOnline.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }
       
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(x => x.Id);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnType("varchar(200)");
            modelBuilder.Entity<Product>().Property(x => x.Value).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Product>().Property(x => x.Image).HasColumnType("varchar(MAX)");
        }
    }
}