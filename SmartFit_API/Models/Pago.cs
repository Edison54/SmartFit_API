using System;
using System.Collections.Generic;

namespace SmartFit_API.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Estado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
