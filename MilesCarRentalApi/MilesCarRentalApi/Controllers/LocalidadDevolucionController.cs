using Domain.InterFaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRentalApi.Controllers
{
    [ApiController]
    [Route("Api/MilesCarRental")]
    public class LocalidadDevolucionController(ILocalidadDevolucion _localidadDevolucion) : Controller
    {
        [HttpPost("LocalidadDevolucion")]
        public async Task<ActionResult<Success>> SetLocalidadDevolucion([FromBody] LocalidadDevolucion localidadDevolucion)
        {
            Success result = await _localidadDevolucion.SetLocalidadDevolucion(localidadDevolucion);
            return result;
        }
    }
}
