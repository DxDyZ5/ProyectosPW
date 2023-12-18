using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObtenerListaNombres.Interfaces;
using ObtenerListaNombres.Models;

namespace ObtenerListaNombres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAdminController : ControllerBase
    {
        private readonly Iusuario UsuarioService;

        public UsuarioAdminController(Iusuario UsuarioService)
        {
            this.UsuarioService = UsuarioService;
        }

        [HttpGet("GetUsuario")]
        public List<UsuarioAdmin> getUsuario()
        {
            return UsuarioService.getUsuario();
        }
    }
}
