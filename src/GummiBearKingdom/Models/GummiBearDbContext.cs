﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{   //When using Entity Framework (EF), must have a class that inhirit DbContext 
    // GummiBear extend DbContext
    public class GummiBearDbContext : DbContext   
    {
        //DbSet<Table> will be set as Table in the SQL database 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public GummiBearDbContext(DbContextOptions<GummiBearDbContext> options)
            : base(options)
            //Options are primary used to select and congifure the data store
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

//Next Configure our Startup class for the app to use Entity Framework