using Hotels.Application.Abstractions.Persistence;
using Hotels.Application.Abstractions.Persistence.Repositories;

using hotels.Application.Contracts.ServicesInterfaces;
using hotels.Application.Services;
using Hotels.Infrastructure.Persistence;
using Hotels.Infrastructure.Persistence.Repositories;

namespace Hotels.Application.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        // TODO: add services
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IHotelService, HotelService>();
        collection.AddScoped<IReservationService, ReservationService>();
        collection.AddScoped<IHotelSuiteService, HotelSuiteService>();

        return collection;
    }
}