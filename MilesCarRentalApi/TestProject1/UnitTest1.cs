using Domain.Models;
using InfraData.Context;
using InfraData.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        private IConfiguration _configuration;
        private DbContextOptions<ConnectionContext> _options;
        private ConnectionContext _context;

        public UnitTest1()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = configBuilder.Build();

            _options = GetOptionsContext();
            _context = new ConnectionContext(_options); 
        }

        private DbContextOptions<ConnectionContext> GetOptionsContext()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ConnectionContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }

        [TestMethod]
        public async Task SetLocalidadDevolucionTest()
        {

            var service = new LocalidadDevolucionService(_context);
            var localidadDevolucion = new LocalidadDevolucion
            {
                Devolucion = "Some value"
            };

            var result = await service.SetLocalidadDevolucion(localidadDevolucion);

            Assert.AreEqual("Éxito", result.Estado);
            Assert.AreEqual("Localidad de devolución agregada correctamente", result.Respuesta);

            var addedLocalidadDevolucion = await _context.LocalidadDevolucion.FirstOrDefaultAsync();
            Assert.IsNotNull(addedLocalidadDevolucion);
            Assert.AreEqual(localidadDevolucion.Devolucion, addedLocalidadDevolucion.Devolucion);
        }

        [TestMethod]
        public async Task SetLocalidadRecogidaTest()
        {
            var service = new LocalidadRecogidaService(_context);
            var localidadRecogida = new LocalidadRecogida
            {
                Recogida = "Some value"
            };


            var result = await service.SetLocalidadRecogida(localidadRecogida);


            Assert.AreEqual("Éxito", result.Estado);
            Assert.AreEqual("Localidad de recogida agregada correctamente", result.Respuesta);

            var addedLocalidadRecogida = await _context.LocalidadRecogida.FirstOrDefaultAsync();
            Assert.IsNotNull(addedLocalidadRecogida);
            Assert.AreEqual(localidadRecogida.Recogida, addedLocalidadRecogida.Recogida);
        }
        [TestMethod]
        public async Task SetLTipoVehiculoTest()
        {
     
            var service = new TipoVehiculoService(_context);
            var tipoVehiculo = new TipoVehiculo
            {
                Tipo = "Some value"
            };
  
            var result = await service.SetTipoVehiculo(tipoVehiculo);
            Assert.AreEqual("Éxito", result.Estado);
            Assert.AreEqual("Tipo vehiculo agregado correctamente", result.Respuesta);
  
            var addedtipovehiculo = await _context.TipoVehiculo.FirstOrDefaultAsync();
            Assert.IsNotNull(addedtipovehiculo);
            Assert.AreEqual(tipoVehiculo.Tipo, addedtipovehiculo.Tipo);
        }
        [TestMethod]
        public async Task SetVehiculoTest()
        {
            var service = new VehiculoService(_context);
            var vehiculo = new Vehiculo
            {
                Id_LocalidadDevolucion =1,
                Id_LocalidadRecogida =1,
                Id_TipoVehiculo =  1,
                Marca = "nissan",
                Modelo = 2023,
                Color = "rojo"

            };  
            var result = await service.SetVehiculo(vehiculo);
            Assert.AreEqual("Éxito", result.Estado);
            Assert.AreEqual("Tipo vehiculo agregado correctamente", result.Respuesta);
            var addedVehiculo = await _context.Vehiculo.FirstOrDefaultAsync();
            Assert.IsNotNull(addedVehiculo);
            Assert.AreEqual(vehiculo.Marca, addedVehiculo.Marca);
            Assert.AreEqual(vehiculo.Modelo, addedVehiculo.Modelo);
        }
        [TestMethod]
        public async Task GetVehiculosDisponiblesTest()
        {
            
            var service = new VehiculoService(_context);
            var vehiculo = new Vehiculo
            {
                Id_LocalidadDevolucion = 1,
                Id_LocalidadRecogida = 1,
                Id_TipoVehiculo = 1,
                Marca = "nissan",
                Modelo = 2023,
                Color = "rojo"

            };           
            var result = await service.VehiculosDisponibles("localidadRecogida", "LocalidadDevolucion");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
