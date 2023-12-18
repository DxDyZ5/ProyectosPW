using IntercambioDisparoPW.Interfaces;
using IntercambioDisparoPW.Models;

namespace IntercambioDisparoPW.Services
{
    public class RegistrarService : Iregistrar
    {
        private readonly IntercambioDisparosContext _intercambioDisparoContext;

        public RegistrarService(IntercambioDisparosContext context)
        {
            _intercambioDisparoContext = context;
        }
       

        public void registrarIntercambio(DateTime fecha, string lugar)
        {
            var registrarI = new IntercambioDeDisparo
            {
                Fecha = fecha,
                Lugar = lugar
            };

            _intercambioDisparoContext.IntercambioDeDisparos.Add(registrarI);
            _intercambioDisparoContext.SaveChanges();
        }

        public void registrarCoordenada(int IdIntercambio, decimal latitud, decimal longitud)
        {
            var registrarC = new Coordenada
            {
                IdIntercambio = IdIntercambio,
                Latitud = latitud,
                Longitud = longitud
            };

            _intercambioDisparoContext.Coordenadas.Add(registrarC);
            _intercambioDisparoContext.SaveChanges();
        }

        public void registrarParticipante(int? IdCoordenadas, string cedula, string nombre, string rol, string? estado)
        {
            var RegistrarP = new Participante
            {
                IdCoordenadas = IdCoordenadas,
                Cedula = cedula,
                Nombre = nombre,
                Rol = rol,
                Estado = estado
            };

            _intercambioDisparoContext.Participantes.Add(RegistrarP);
            _intercambioDisparoContext.SaveChanges();
        }
    }
}
