using Entitites.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<News> News { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNewUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }



        public static string GetStringConnection()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=DDD-Api-News;Trusted_Connection=True;MultipleActiveResultSets=true";

            return connectionString;
        }

    }
}
