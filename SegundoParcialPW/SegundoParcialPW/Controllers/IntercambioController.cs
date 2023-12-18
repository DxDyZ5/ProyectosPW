using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;
using System.Linq;

namespace SegundoParcialPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntercambioController : ControllerBase
    {
        private readonly Iregistrar _registrar;
      
        public IntercambioController(Iregistrar registrar)
        {
            _registrar = registrar;
        }


            [HttpPost("RegistrarIntercambio")]
        public IActionResult RegistrarIntercambio(DateTime fecha, string lugar)
        {
            try
            {
                _registrar.registrarIntercambio(fecha, lugar);

                return Ok(new { mensaje = "Intercambio registrado exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(new { mensaje = "Error al registrar el intercambio " + e });
            }
        }



        [HttpPost("RegistrarCoordenada")]
        public IActionResult RegistrarCoordenada( int IdIntercambio, decimal latitud, decimal longitud)
        {
            try
            {
                _registrar.registrarCoordenada( IdIntercambio, latitud, longitud);

                return Ok(new { mensaje = "Coordenada registrado exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(new { mensaje = "Error al registrar Coordenada" + e });
            }
        }



        [HttpPost("RegistrarParticipante")]
        public IActionResult RegistrarParticipante(int? IdCoordenadas, string cedula, string nombre, string rol, string? estado)
        {
            try
            {
                _registrar.registrarParticipante(IdCoordenadas, cedula, nombre, rol, estado);

                return Ok(new { mensaje = "Participante registrado exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(new { mensaje = "Error al registrar Participante" + e });
            }
        }
    }


}
