using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace onlineShopSolution.Data.EF
{
    public class onlineShopSolutionDbContext : IDesignTimeDbContextFactory<OnlineShopDbContext>
    {
        public OnlineShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())  //add reference
               .AddJsonFile("appsettings.json")               //add reference
               .Build();

            var connectionString = configuration.GetConnectionString("onlineShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<OnlineShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new OnlineShopDbContext(optionsBuilder.Options);
        }
    }
   
}
