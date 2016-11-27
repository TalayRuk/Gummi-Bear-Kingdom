using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{   //When using Entity Framework (EF), must have a class that inhirit DbContext 
    // GummiBear extend DbContext
    public class GummiBearDbContext : DbContext   
    {
        public GummiBearDbContext(DbContextOptions<GummiBearDbContext> options)
           : base(options)
        //Options are primary used to select and congifure the data store
        { }

        //DbSet<Table> will be set as Table in the SQL database 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=GummiBearKingdom;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

//Next Configure our Startup class for the app to use Entity Framework