using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Persistence.Contexts;
using PhoneBookAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence
{
    public static class ServiceRegistration
    {
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PhoneBookAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        services.AddScoped<ICommunicationReadRepository, CommunicationReadRepository>();
        services.AddScoped<ICommunicationWriteRepository, CommunicationWriteRepository>();
        services.AddScoped<IContactReadRepository, ContactReadRepository>();
        services.AddScoped<IContactWriteRepository, ContactWriteRepository>();
        services.AddScoped<IReportReadRepository, ReportReadRepository>();
        services.AddScoped<IReportWriteRepository, ReportWriteRepository>();
    }
}
}
