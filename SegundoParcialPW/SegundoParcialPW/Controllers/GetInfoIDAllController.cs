using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundoParcialPW.DTOS;
using SegundoParcialPW.Interfaces;

namespace SegundoParcialPW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetInfoIDAllController : ControllerBase
    {
       private readonly IgetAll _IgetAll;

        public GetInfoIDAllController(IgetAll iintercambio)
        {
            _IgetAll = iintercambio;
        }

        [HttpGet("GetIntercambio")]
        public IActionResult getIntercambio() 
        {
            var intercamio = _IgetAll.getIntercambio();

            var InterDto = intercamio.Select(intercambio => new IntercambioDTO
            {
                IdIntercambio = intercambio.IdIntercambio,
                Fecha = intercambio.Fecha,
                Lugar = intercambio.Lugar
            }).ToList();

            return Ok(InterDto);
        }

        [HttpGet("GetCoordenada")]
        public IActionResult getCoordenadas()
        {
            var coordenadas = _IgetAll.getCoordenada();

            var coorDto = coordenadas.Select(coordenadas => new CoordenadasDTO
            {
                IdCoordenadas = coordenadas.IdCoordenadas,
                IdIntercambio = coordenadas.IdIntercambio,
                Latitud = coordenadas.Latitud,
                Longitud = coordenadas.Longitud
            }).ToList();

            return Ok(coorDto);
        }



        [HttpGet("GetParticipante")]
        public IActionResult getParticipantes()
        {
            var participantes = _IgetAll.GetParticipantes();

            var PartDto = participantes.Select(participante => new ParticipanteDTO
            {
                IdParticipantes = participante.IdParticipantes,
                IdCoordenadas = participante.IdCoordenadas,
                Cedula = participante.Cedula,
                Nombre = participante.Nombre,
                Rol = participante.Rol,
                Estado = participante.Estado
            }).ToList();

            return Ok(PartDto);
        }
    }
}
