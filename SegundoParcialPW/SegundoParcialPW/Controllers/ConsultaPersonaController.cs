using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundoParcialPW.Interfaces;

namespace SegundoParcialPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaPersonaController : ControllerBase
    {
        IConsultaPersona _consultaPersona;

        public ConsultaPersonaController(IConsultaPersona consultaPersona)
        {
            _consultaPersona = consultaPersona;
        }

        [HttpGet("ConsultaPersona")]
        public IActionResult ConsultaPersona( string  cedula)
        {
            if (string.IsNullOrEmpty(cedula))
                return BadRequest("Cedula no puede estar vacia");


            var consulta = _consultaPersona.COnsultaPersona(cedula);
            return Ok(consulta);
        }
    }
}
