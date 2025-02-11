﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfrastructure
{
    public class UserDbConTextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("UserDbSC");
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new UserDbContext(optionsBuilder.Options);
        }
    }
}