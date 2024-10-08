using LezzetKitabi.Domain.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Contexts
{
    internal class LezzetKitabiDbContextFactory : IDesignTimeDbContextFactory<LezzetKitabiDbContext>
    {
        public LezzetKitabiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LezzetKitabiDbContext>();


            var connectionString = Configuration.(ConstVariables.ConnectionString);
            optionsBuilder.UseSqlServer(connectionString);

            return new LezzetKitabiDbContext(optionsBuilder.Options);
        }
    }
}
