using Domain.InterFaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRentalApi.Controllers
{
    [ApiController]
    [Route("Api/MilesCarRental")]
    public class LocalidadRecogidaController(ILocalidadRecogida _LocalidadRecogida) : Controller
    {
        [HttpPost("LocalidadRecogida")]
        public async Task<ActionResult<Success>> SetLocalidadRecogida([FromBody] LocalidadRecogida localidadRecogida)
        {
            Success result = await _LocalidadRecogida.SetLocalidadRecogida(localidadRecogida);
            return result;
        }
    }

}
