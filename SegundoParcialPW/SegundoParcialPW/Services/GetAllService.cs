using SegundoParcialPW.Interfaces;
using SegundoParcialPW.Models;

namespace SegundoParcialPW.Services
{
    public class GetAllService : IgetAll
    {
        IntercambioPoliciaContext _IntercambioPoliciaContext;

        public GetAllService(IntercambioPoliciaContext intercambioPoliciaContext)
        {
            _IntercambioPoliciaContext = intercambioPoliciaContext;
        }

        public List<Coordenada> getCoordenada()
        {
           return _IntercambioPoliciaContext.Coordenadas.ToList();
        }

        public List<IntercambioDeDisparo> getIntercambio()
        {
          return  _IntercambioPoliciaContext.IntercambioDeDisparos.ToList();
        }

        public List<Participante> GetParticipantes()
        {
           return _IntercambioPoliciaContext.Participantes.ToList();
        }
    }
}
