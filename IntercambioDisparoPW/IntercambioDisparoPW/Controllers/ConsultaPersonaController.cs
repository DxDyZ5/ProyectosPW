using IntercambioDisparoPW.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntercambioDisparoPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaPersonaController : ControllerBase
    {
        IconsultaPersona _consultaPersona;

        public ConsultaPersonaController(IconsultaPersona consultaPersona)
        {
            _consultaPersona = consultaPersona;
        }

        [HttpGet("ConsultaPersona")]
        public IActionResult ConsultaPersona(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
                return BadRequest("Cedula no puede estar vacia");


            var consulta = _consultaPersona.consultaPersona(cedula);
            return Ok(consulta);
        }
    }
}
