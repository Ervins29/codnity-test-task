using CodnityTestTask.Data.DbContexts;
using CodnityTestTask.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodnityTestTask.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<TodoDbContext>(db =>
            db.UseSqlServer(configurationManager.GetConnectionString("DatabaseConnectionString")));

        serviceCollection.AddScoped<ITodoRepository, TodoRepository>();

        return serviceCollection;
    }
}