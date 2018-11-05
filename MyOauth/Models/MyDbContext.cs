using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyOauth.Models;

namespace MyOauth.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Credential> Credentials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasIndex(b => b.Email).IsUnique();
        }
    }
}
