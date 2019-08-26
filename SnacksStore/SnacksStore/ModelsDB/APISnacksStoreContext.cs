using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SnacksStore.ModelsDB
{
    public partial class APISnacksStoreContext : DbContext
    {
        public APISnacksStoreContext()
        {
        }

        public APISnacksStoreContext(DbContextOptions<APISnacksStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LikingProducts> LikingProducts { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<StockUnits> StockUnits { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS2014;User Id=sa;password=123456;Database=APISnacksStore;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(260);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Size).HasMaxLength(100);
            });

            modelBuilder.Entity<StockUnits>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.StockCount).HasColumnName("stockCount");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(80);

                entity.Property(e => e.LastName).HasMaxLength(80);

                entity.Property(e => e.Password).HasMaxLength(120);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Token).HasMaxLength(300);

                entity.Property(e => e.Username).HasMaxLength(130);
            });
        }
    }
}
