using System;
using System.Collections.Generic;

namespace SmartFit_API.Models
{
    public partial class ExercisesMachine
    {
        public int IdEjercicio { get; set; }
        public int IdUsuario { get; set; }
        public string NameExercise { get; set; } = null!;
        public int Peso { get; set; }
        public string CantidadRepeticiones { get; set; } = null!;
        public string Tiempo { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
