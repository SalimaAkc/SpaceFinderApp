using Microsoft.EntityFrameworkCore;
using SpacefinderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SpacefinderApp.DatabaseContext
{
    public class DatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            _connectionString = configuration.GetConnectionString("Default");
        }
    }   

    // Use _connectionString for database operations
}
