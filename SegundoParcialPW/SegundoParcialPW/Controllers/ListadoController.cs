using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundoParcialPW.Interfaces;

namespace SegundoParcialPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoController : ControllerBase
    {
        Ilistado _Ilistado;

        public ListadoController(Ilistado Ilistado)
        {
            _Ilistado = Ilistado;
        }


        [HttpGet("Listado")]
        public IActionResult GetListado(DateTime FechaInicio, DateTime FechaFin) 
        {
           var listado =  _Ilistado.ListadoDeEnfrentamiento(FechaInicio, FechaFin);
            
            return Ok(listado);
        }
    }
}
