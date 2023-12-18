using ObtenerListaNombres.Interfaces;
using ObtenerListaNombres.Models;

namespace ObtenerListaNombres.Services
{
    public class UsuarioService : Iusuario
    {

        private readonly PersonajesSERIEPracticaContext personajesSERIEPracticaContext;


        public UsuarioService(PersonajesSERIEPracticaContext context)
        {
            personajesSERIEPracticaContext = context;
        }

        public List<UsuarioAdmin> getUsuario()
        {

            return personajesSERIEPracticaContext.UsuarioAdmins.ToList();
        }
    }


}
