using SegundoParcialPW.Models;

namespace SegundoParcialPW.Interfaces
{
    public interface IgetAll
    {
        public List<IntercambioDeDisparo> getIntercambio();

        public List<Coordenada> getCoordenada();

        public List<Participante> GetParticipantes();
    }
}
