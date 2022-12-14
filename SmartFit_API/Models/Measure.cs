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
        public decimal BodyFat { get; set; }
        public decimal SkeletalMuscle { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
    }
}
