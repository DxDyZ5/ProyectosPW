using System;
using System.Collections.Generic;

namespace IntercambioDisparoPW.Models
{
    public partial class Participante
    {
        public int IdParticipantes { get; set; }
        public int? IdCoordenadas { get; set; }
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string? Estado { get; set; }

        public virtual Coordenada? IdCoordenadasNavigation { get; set; }
    }
}
