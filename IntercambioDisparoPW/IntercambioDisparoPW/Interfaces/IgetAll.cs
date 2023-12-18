using IntercambioDisparoPW.Models;

namespace IntercambioDisparoPW.Interfaces
{
    public interface IgetAll
    {
        public List<IntercambioDeDisparo> GetIntercambioDeDisparos();

        public List<Coordenada> GetCoordenadas();

        public List<Participante> GetParticipantes();


    }
}
