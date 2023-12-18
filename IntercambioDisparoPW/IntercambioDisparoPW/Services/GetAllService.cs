using IntercambioDisparoPW.Interfaces;
using IntercambioDisparoPW.Models;

namespace IntercambioDisparoPW.Services
{
    public class GetAllService : IgetAll
    {
        IntercambioDisparosContext _IntercambioDisparoContext;


        public GetAllService(IntercambioDisparosContext intercambioDisparoContext)
        {
            _IntercambioDisparoContext = intercambioDisparoContext;
        }

        public List<Coordenada> GetCoordenadas()
        {
            return _IntercambioDisparoContext.Coordenadas.ToList();
        }

        public List<IntercambioDeDisparo> GetIntercambioDeDisparos()
        {
            return _IntercambioDisparoContext.IntercambioDeDisparos.ToList();
        }

        public List<Participante> GetParticipantes()
        {
            return _IntercambioDisparoContext.Participantes.ToList();
        }
    }
}
