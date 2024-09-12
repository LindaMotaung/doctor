using Doctorly.Scheduler.Application.Contracts.Persistence;
using Doctorly.Scheduler.Persistence.DatabaseContext;
using Doctorly.Scheduler.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doctorly.Scheduler.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DoctorlyDatabaseContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DoctorlyDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<IEventAllocationRepository, EventAllocationRepository>();
            services.AddScoped<IEventRequestRepository, EventRequestRepository>();

            return services;
        }
    }
}
