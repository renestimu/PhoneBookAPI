using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PhoneBookAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PhoneBookAPIDbContext>
    {
        public PhoneBookAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<PhoneBookAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
