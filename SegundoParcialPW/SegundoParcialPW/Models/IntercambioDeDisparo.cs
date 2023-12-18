using System;
using System.Collections.Generic;

namespace SegundoParcialPW.Models
{
    public partial class IntercambioDeDisparo
    {
        public IntercambioDeDisparo()
        {
            Coordenada = new HashSet<Coordenada>();
        }

        public int IdIntercambio { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = null!;

        public virtual ICollection<Coordenada> Coordenada { get; set; }
    }
}
