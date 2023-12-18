using IntercambioDisparoPW.Interfaces;
using IntercambioDisparoPW.Models;
using Microsoft.EntityFrameworkCore;

namespace IntercambioDisparoPW.Services
{
    public class ListadoService : Ilistado
    {
        IntercambioDisparosContext _intercambioDisparoContext;

        public ListadoService(IntercambioDisparosContext context)
        {
            _intercambioDisparoContext = context;
        }
        public List<object> ListadoIntercambioDisparos(DateTime FechaInicio, DateTime FechaFin)
        {
            var query = _intercambioDisparoContext.Coordenadas
                          .Include(c => c.IdIntercambioNavigation)
                          .Where(c => c.IdIntercambioNavigation.Fecha >= FechaInicio.Date && c.IdIntercambioNavigation.Fecha <= FechaFin.Date)
                          .AsQueryable();

            var result = query.Select(c => new
            {
                IdCoordenadas = c.IdCoordenadas,
                IdIntercambio = c.IdIntercambio,
                Latitud = c.Latitud,
                Longitud = c.Longitud,
                Intercambio = c.IdIntercambioNavigation != null ? new
                {
                    Fecha = c.IdIntercambioNavigation.Fecha,
                    Lugar = c.IdIntercambioNavigation.Lugar
                } : null
            }).ToList();

            return result.Cast<object>().ToList();
        }
    }
}
