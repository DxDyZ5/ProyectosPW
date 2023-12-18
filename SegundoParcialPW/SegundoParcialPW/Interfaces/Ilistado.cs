using SegundoParcialPW.DTOS;
using SegundoParcialPW.Models;

namespace SegundoParcialPW.Interfaces
{
    public interface Ilistado
    {
        public List<object> ListadoDeEnfrentamiento(DateTime fechaInicio, DateTime FechaFin);
    }
}
