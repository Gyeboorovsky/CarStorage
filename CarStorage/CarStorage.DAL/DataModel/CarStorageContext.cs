using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarStorage.DAL.DataModel
{
    public partial class CarStorageContext : DbContext
    {
        public CarStorageContext()
        {
        }

        public CarStorageContext(DbContextOptions<CarStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyType> BodyType { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicle { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("BodyType", "dict");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
