using IntercambioDisparoPW.DTOS;
using IntercambioDisparoPW.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntercambioDisparoPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
        private readonly IgetAll _IgetAll;

        public GetAllController(IgetAll iintercambio)
        {
            _IgetAll = iintercambio;
        }

        [HttpGet("GetIntercambio")]
        public IActionResult getIntercambio()
        {
            var intercamio = _IgetAll.GetIntercambioDeDisparos();

            var InterDto = intercamio.Select(intercambio => new IntercambioDTO
            {
                IdIntercambio = intercambio.IdIntercambio,
                Fecha = intercambio.Fecha,
                Lugar = intercambio.Lugar
            }).ToList();

            return Ok(InterDto);
        }


        [HttpGet("GetCoordenada")]
        public IActionResult GetCoordenada()
        {
            var coordenada = _IgetAll.GetCoordenadas();

            var coorDto = coordenada.Select(C => new CoordenadasDTO
            {
                IdCoordenadas = C.IdCoordenadas,
                IdIntercambio = C.IdIntercambio,
                Latitud = C.Latitud,
                Longitud = C.Longitud

            }).ToList();

            return Ok(coorDto);
        }


        [HttpGet("GetParticipante")]
        public IActionResult Getparticipante()
        {
            var participante = _IgetAll.GetParticipantes();

            var partDto = participante.Select(P => new ParticipanteDTO
            {
                IdParticipantes = P.IdParticipantes,
                IdCoordenadas = P.IdCoordenadas,
                Cedula = P.Cedula,
                Nombre = P.Nombre,
                Rol =  P.Rol, 
                Estado = P.Estado

            }).ToList();

            return Ok(partDto);
        }
    }
}
