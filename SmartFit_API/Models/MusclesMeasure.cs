using System;
using System.Collections.Generic;

namespace SmartFit_API.Models
{
    public partial class MusclesMeasure
    {
        public int IdMuscle { get; set; }
        public int IdUsuario { get; set; }
        public string Musculo { get; set; } = null!;
        public decimal Medida { get; set; }
        public DateTime FechaMedida { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
    }
}
