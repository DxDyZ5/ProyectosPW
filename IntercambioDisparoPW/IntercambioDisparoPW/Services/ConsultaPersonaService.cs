using IntercambioDisparoPW.Interfaces;
using IntercambioDisparoPW.Models;
using Microsoft.EntityFrameworkCore;

namespace IntercambioDisparoPW.Services
{
    public class ConsultaPersonaService : IconsultaPersona
    {
        IntercambioDisparosContext _intercambioPoliciaContext;

        public ConsultaPersonaService(IntercambioDisparosContext context)
        {
            _intercambioPoliciaContext = context;
        }
        public List<object> consultaPersona(string cedula)
        {
            var personData = _intercambioPoliciaContext.Participantes
             .Where(p => p.Cedula.Contains(cedula))
                .Include(p => p.IdCoordenadasNavigation)
                 .ThenInclude(c => c.IdIntercambioNavigation)
                .ToList();

            var result = personData.Select(p => new
            {
                Nombre = p.Nombre,
                Rol = p.Rol,
                cedula = p.Cedula,
                Coordenadas = p.IdCoordenadasNavigation != null ? new
                {
                    Latitud = p.IdCoordenadasNavigation.Latitud,
                    Longitud = p.IdCoordenadasNavigation.Longitud,
                    Intercambio = p.IdCoordenadasNavigation.IdIntercambioNavigation != null ? new
                    {
                        Fecha = p.IdCoordenadasNavigation.IdIntercambioNavigation.Fecha,
                        Lugar = p.IdCoordenadasNavigation.IdIntercambioNavigation.Lugar
                    } : null
                } : null
            }).ToList();

            return result.Cast<object>().ToList();
        }
    }
}
