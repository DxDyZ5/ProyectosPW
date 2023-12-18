using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObtenerListaNombres.Interfaces;
using ObtenerListaNombres.Models;
using ObtenerListaNombres.Services;

namespace ObtenerListaNombres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly Inombre nombreServices;

        public PersonajesController(Inombre nombreServices)
        {
            this.nombreServices = nombreServices;
        }

        [HttpGet("ObtenerPersonajes")]
        public List<PersonajesNombre> getPersonajes()
        {
            return nombreServices.getPersonajes();
        }
}
}
