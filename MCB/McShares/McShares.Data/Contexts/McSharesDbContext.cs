using McShares.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace McShares.Data.Contexts
{
    public class McSharesDbContext : DbContext
    {
        public McSharesDbContext(DbContextOptions<McSharesDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        //entities
        public DbSet<Customer> Customer { get; set; }

        public DbSet<DocumentCustomerSharesStaging> DocumentCustomerSharesStaging { get; set; }

        public DbSet<AllDetails> AllDetails { get; set; }

    }
}
