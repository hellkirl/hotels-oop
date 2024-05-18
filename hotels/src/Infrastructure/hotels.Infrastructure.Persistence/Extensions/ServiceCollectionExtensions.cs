using Hotels.Application.Abstractions.Persistence.Repositories;
using Hotels.Application.Abstractions.Persistence;
using hotels.Application.Models.HotelModels;

using hotels.Infrastructure.Persistence.Context;
using Hotels.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotels.Infrastructure.Persistence.Extensions;

using Hotels.Infrastructure.Persistence.Migrations;
using Hotels.Infrastructure.Persistence.Plugins;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection,  IConfiguration configuration)
    {
        AddContext(collection, configuration);
        
        // TODO: add repositories
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IUserInfoRepository, UserInfoRepository>();
        collection.AddScoped<IHotelRepository, HotelRepository>();
        collection.AddScoped<IHotelChainRepository, HotelChainRepository>();
        collection.AddScoped<ISuiteRepository, SuiteRepository>();
        collection.AddScoped<IReservationRepository, ReservationRepository>();
        collection.AddScoped<ILocationRepository, LocationRepository>();
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        return collection;
    }
    
    private static IServiceCollection AddContext(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}