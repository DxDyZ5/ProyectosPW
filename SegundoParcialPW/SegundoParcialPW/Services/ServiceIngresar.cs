using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;

namespace SegundoParcialPW.Services
{
    public class ServiceIngresar : Iregistrar
    {
        private readonly IntercambioPoliciaContext _intercambioPoliciaContext;

        public ServiceIngresar(IntercambioPoliciaContext context)
        {
            _intercambioPoliciaContext = context;
        }
  
        public void registrarIntercambio(DateTime fecha, string lugar)
        {
            var registrarI = new IntercambioDeDisparo
            {
                Fecha = fecha,
                Lugar = lugar
            };

            _intercambioPoliciaContext.IntercambioDeDisparos.Add(registrarI);
            _intercambioPoliciaContext.SaveChanges();
        }
        public void registrarCoordenada(int IdIntercambio, decimal latitud, decimal longitud)
        {
            var registrarC = new Coordenada
            {
                IdIntercambio = IdIntercambio,
                Latitud = latitud,
                Longitud = longitud
            };

            _intercambioPoliciaContext.Coordenadas.Add(registrarC);
            _intercambioPoliciaContext.SaveChanges();
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

            _intercambioPoliciaContext.Participantes.Add(RegistrarP);
            _intercambioPoliciaContext.SaveChanges();
        }
    }
}
