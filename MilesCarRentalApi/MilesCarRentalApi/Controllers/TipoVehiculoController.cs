using Domain.InterFaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRentalApi.Controllers
{
    [ApiController]
    [Route("Api/MilesCarRental")]
    public class TipoVehiculoController(ITipoVehiculo _tipoVehiculo) : Controller
    {  
            [HttpPost("TipoVehiculo")]
            public async Task<ActionResult<Success>> SetTipoVehiculo([FromBody] TipoVehiculo tipoVehiculo)
            {
                Success result = await _tipoVehiculo.SetTipoVehiculo(tipoVehiculo);
                return result;
            }        
    }
}
