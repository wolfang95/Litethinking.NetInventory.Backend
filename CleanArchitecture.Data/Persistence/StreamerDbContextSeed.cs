using Litethinking.NetInventory.Backend.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Infrastructure.Persistence
{
    public class CompanyDbContextSeed
    {
        public static async Task SeedAsync(CompanyDbContext context, ILogger<CompanyDbContextSeed> logger)
        {
            if (!context.Companies!.Any())
            {
                context.Companies!.AddRange(GetPreconfiguredCompany());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(CompanyDbContext).Name);
            }

        }

        private static IEnumerable<Company> GetPreconfiguredCompany()
        {
            return new List<Company>
            {
                new Company {CreatedBy = "wolfang", Name = "Netflix HBP", Url = "httpcom" },
                new Company {CreatedBy = "wolfang", Name = "Netflix VIP", Url = "httpcom" },
            };

        }


    }
}
