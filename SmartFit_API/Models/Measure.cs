using System;
using System.Collections.Generic;

namespace SmartFit_API.Models
{
    public partial class Measure
    {
        public int IdMeasure { get; set; }
        public int IdUsuario { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public decimal Grasa { get; set; }
        public decimal GrasaViseral { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
