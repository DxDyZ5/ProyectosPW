using Microsoft.EntityFrameworkCore;
using SegundoParcialPW.DTOS;
using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;

namespace SegundoParcialPW.Services
{
    public class ListadoService : Ilistado
    {
        IntercambioPoliciaContext _intercambioPoliciaContext;

        public ListadoService(IntercambioPoliciaContext context)
        {
            _intercambioPoliciaContext = context;
        }

        public List<object> ListadoDeEnfrentamiento(DateTime fechaInicio, DateTime FechaFin)
        {
            var query = _intercambioPoliciaContext.Coordenadas
              .Include(c => c.IdIntercambioNavigation)
              .Where(c => c.IdIntercambioNavigation.Fecha >= fechaInicio.Date && c.IdIntercambioNavigation.Fecha <= FechaFin.Date)
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
