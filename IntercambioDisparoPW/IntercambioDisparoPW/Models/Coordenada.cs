using System;
using System.Collections.Generic;

namespace IntercambioDisparoPW.Models
{
    public partial class Coordenada
    {
        public Coordenada()
        {
            Participantes = new HashSet<Participante>();
        }

        public int IdCoordenadas { get; set; }
        public int? IdIntercambio { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        public virtual IntercambioDeDisparo? IdIntercambioNavigation { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
