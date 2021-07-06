using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LogInRepostoryLayer;
using LogInDataLayer;

namespace LogInRepostoryLayer
{
    public partial class LogInRepostory : DbContext
    {
        public LogInRepostory()
        {
        }

        public LogInRepostory(DbContextOptions<LogInRepostory> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Username, "UQ__customer__F3DBC5721B108432")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(20)
                    .HasColumnName("ZipCode");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Email");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("Phone");
                entity.Property(e => e.HomeCoordinate)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Home_Coordinate");
                entity.Property(e => e.WanderingRadius)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Wandering_Radius");


            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}