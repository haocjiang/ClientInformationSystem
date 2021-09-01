using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ClientInfoSysDbContext:DbContext
    {
        public ClientInfoSysDbContext(DbContextOptions<ClientInfoSysDbContext> options):base(options)
        {

        }
        // Create DbSets Properties inside DbContext
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(ConfigureClient);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
            modelBuilder.Entity<Interaction>(ConfigureInteraction);
        }

        private void ConfigureClient(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.Phones).HasMaxLength(30).IsRequired(false);
            builder.Property(c => c.Address).HasMaxLength(100).IsRequired(false);
            builder.Property(c => c.AddedOn).IsRequired(false);
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Password).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.Designation).HasMaxLength(50).IsRequired(false);
        }

        private void ConfigureInteraction(EntityTypeBuilder<Interaction> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.ClientId).IsRequired(false);
            builder.Property(i => i.EmpId).IsRequired(false);
            builder.Property(i => i.IntType).HasMaxLength(1).IsRequired(false);
            builder.Property(i => i.IntDate).IsRequired(false);
            builder.Property(i => i.Remarks).HasMaxLength(500).IsRequired(false);
        }
    }
}
