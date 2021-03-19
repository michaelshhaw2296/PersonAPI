using FlexeraAPI.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                Address = "Test Address",
                Age = 24,
                Email = "mtest@email.com",
                FirstName = "Michael",
                LastName = "Shaw"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                Address = "Test Address",
                Age = 44,
                Email = "ddd@email.com",
                FirstName = "Joe",
                LastName = "Bloggs"
            });
        }
    }
}
