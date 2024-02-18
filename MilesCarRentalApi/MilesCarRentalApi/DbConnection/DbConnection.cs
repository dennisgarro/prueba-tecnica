using Domain.InterFaces;
using Domain.Models;
using InfraData.Context;
using InfraData.Services;
using Microsoft.EntityFrameworkCore;

namespace MilesCarRentalApi.DbConnection
{
    public  static class DbConnection
    {
        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ConnectionContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });            
            service.AddTransient<ILocalidadDevolucion,LocalidadDevolucionService>();
            service.AddTransient<ILocalidadRecogida, LocalidadRecogidaService>();
            service.AddTransient<ITipoVehiculo, TipoVehiculoService>();
            service.AddTransient<IVehiculo, VehiculoService>();
            return service; 
        }
    }
}
