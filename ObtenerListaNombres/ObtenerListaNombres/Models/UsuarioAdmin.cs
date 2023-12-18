using System;
using System.Collections.Generic;

namespace ObtenerListaNombres.Models
{
    public partial class UsuarioAdmin
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Password { get; set; }
    }
}
