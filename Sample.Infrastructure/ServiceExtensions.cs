using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Repository;
using Sample.Application.Service;
using Sample.Infrastructure.Persistence.Repository;
using Sample.Infrastructure.Services;

namespace Sample.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Persistence.SampleDBContext>(op =>
            {
                op.UseSqlServer(connStr);
            });
            services.AddSingleton<IEmailService, FakeEmailService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCredentialRepository, UserCredentialRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
