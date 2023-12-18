using ObtenerListaNombres.Interfaces;
using ObtenerListaNombres.Models;

namespace ObtenerListaNombres.Services
{
    public class NombreServices : Inombre
    {
        private readonly PersonajesSERIEPracticaContext personajesSERIEPracticaContext;


        public NombreServices(PersonajesSERIEPracticaContext context)
        {
            personajesSERIEPracticaContext = context;
        }
        public List<PersonajesNombre> getPersonajes()
        {
            return personajesSERIEPracticaContext.PersonajesNombres.ToList();
        }
    }
}
