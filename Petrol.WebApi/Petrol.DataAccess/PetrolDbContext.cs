using Microsoft.EntityFrameworkCore;
using Petrol.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petrol.DataAccess
{
    /// <summary>
    /// Entity Framework Data Context for the database
    /// </summary>
    public class PetrolDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public PetrolDbContext(DbContextOptions<PetrolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Question").HasKey(p => p.Id);

            modelBuilder.Entity<Question>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Question>(eb =>
            {
                eb.Property(b => b.AskedQuestion)
                .HasColumnType("varchar(200)")
                .IsRequired();

                eb.Property(b => b.Answer)
                .HasColumnType("varchar(1000)")
                .IsRequired();
            });
        }

    }
}
