using Domain.InterFaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRentalApi.Controllers
{
    [ApiController]
    [Route("Api/MilesCarRental")]
    public class VehiculoController(IVehiculo _vehiculo) : Controller
    {
        [HttpPost("Vehiculo")]
        public async Task<ActionResult<Success>> SetTipoVehiculo([FromBody] Vehiculo vehiculo)
        {
            Success result = await _vehiculo.SetVehiculo(vehiculo);
            return result;
        }
        [HttpGet("VehiculosDisponibles")]
        public async Task<ActionResult<List<Disponibilidad>>> GetDisponibilidad(string LocalidadRecogida, string LocalidadDevolucion)
        {
            List<Disponibilidad> result = await _vehiculo.VehiculosDisponibles(LocalidadRecogida, LocalidadDevolucion);
            return result;
        }
        
    }
}
