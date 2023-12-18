using System;
using System.Collections.Generic;

namespace ObtenerListaNombres.Models
{
    public partial class PersonajesNombre
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Imagen { get; set; }
        public string? AltText { get; set; }
        public string? FechaDeNacimiento { get; set; }
        public string? Descripcion { get; set; }
        public string? Habilidad { get; set; }
    }
}
