﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlContext:DbContext
    {
        public MySqlContext(){}
        public MySqlContext(DbContextOptions<MySqlContext> options):base(options){}
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name= "Name",
                Description = "Description",    
                Price=69,
                ImageUrl= "https://github.com/rafeseth/erudio-microservices-dotnet6/blob/main/ShoppingImages/Caneca-capitao-america.png?raw=true",
                CategoryName= "Caneca",


            });
        }
    }
}
