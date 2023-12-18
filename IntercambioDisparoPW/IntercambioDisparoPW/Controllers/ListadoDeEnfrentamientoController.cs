using IntercambioDisparoPW.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntercambioDisparoPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoDeEnfrentamientoController : ControllerBase
    {
        Ilistado _Ilistado;

        public ListadoDeEnfrentamientoController(Ilistado Ilistado)
        {
            _Ilistado = Ilistado;
        }


        [HttpGet("Listado")]
        public IActionResult GetListado(DateTime FechaInicio, DateTime FechaFin)
        {
            var listado = _Ilistado.ListadoIntercambioDisparos(FechaInicio, FechaFin);

            return Ok(listado);
        }
    }
}
