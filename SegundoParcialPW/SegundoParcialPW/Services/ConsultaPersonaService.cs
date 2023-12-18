using Microsoft.EntityFrameworkCore;
using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;

namespace SegundoParcialPW.Services
{
    public class ConsultaPersonaService : IConsultaPersona
    {
        IntercambioPoliciaContext _intercambioPoliciaContext;

        public ConsultaPersonaService(IntercambioPoliciaContext context)
        {
            _intercambioPoliciaContext = context;
        }
        public List<object> COnsultaPersona(string cedula)
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
