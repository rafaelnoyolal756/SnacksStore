using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    public partial class SnacksStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LikingProducts> LikingProducts { get; set; }
        public DbSet<StockUnits> StockUnits { get; set; }
        //public DbSet<Role> Roleses { get; set; }

        public SnacksStoreDbContext(DbContextOptions<SnacksStoreDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //        foreach (var entity in modelBuilder.Model.GetEntityTypes()
    //.Where(t =>
    //    t.ClrType.GetProperties()
    //        .Count(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(KeyAttribute))) > 1))
    //        {
    //            // get the keys in the appropriate order
    //            var orderedKeys = entity.ClrType
    //                .GetProperties()
    //                .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(KeyAttribute)))
    //                .OrderBy(p =>
    //                    p.CustomAttributes.Single(x => x.AttributeType == typeof(ColumnAttribute))?
    //                        .NamedArguments?.Single(y => y.MemberName == nameof(ColumnAttribute.Order))
    //                        .TypedValue.Value ?? 0)
    //                .Select(x => x.Name)
    //                .ToArray();

    //            // apply the keys to the model builder
    //            modelBuilder.Entity(entity.ClrType).HasKey(orderedKeys);
    //        }
            modelBuilder.Entity<User>().HasIndex(u => new { u.FirstName, u.LastName });
            modelBuilder.Entity<Product>().HasIndex(p => new { p.Name, p.Price });
            modelBuilder.Entity<User>().HasMany(c => c.UserProducts).WithOne().HasForeignKey(e => new { e.UserId, e.ProductId }).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<StockUnits>().HasMany(s => s.StockUnitsProducts).WithOne().HasForeignKey(e => new { e.StockUnitsId, e.ProductId }).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Product>().HasMany(l => l.ProductsLikingProducts).WithOne().HasForeignKey(p => new { p.LikingProductsId, p.ProductId }).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<LikingProducts>()
           .HasKey(c => new { c.ProductId, c.UserId });
          
        }
    }
}
