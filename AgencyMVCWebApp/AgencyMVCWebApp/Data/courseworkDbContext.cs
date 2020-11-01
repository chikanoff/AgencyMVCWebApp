using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AgencyMVCWebApp.Models;

namespace AgencyMVCWebApp.Data
{
    public partial class courseworkDbContext : DbContext
    {
        public courseworkDbContext()
        {
        }

        public courseworkDbContext(DbContextOptions<courseworkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ConfirmationDocument> ConfirmationDocuments { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<ToiPolicy> ToiPolicies { get; set; }
        public virtual DbSet<TypeOfinsurance> TypesOfinsurance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=DESKTOP-3DPM8BP\\SQLEXPRESS;Database=courseworkDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
