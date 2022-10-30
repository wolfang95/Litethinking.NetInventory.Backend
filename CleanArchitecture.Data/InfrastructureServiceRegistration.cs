using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Models;
using Litethinking.NetInventory.Backend.Infraestructure.AzureBlobStorage;
using Litethinking.NetInventory.Backend.Infrastructure.Email;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CompanyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAzureBlobStorageService, AzureBlobStorageService>();

            return services;
        }

    }
}
