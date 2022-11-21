using System;
using System.Collections.Generic;

namespace SmartFit_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ExercisesMachines = new HashSet<ExercisesMachine>();
            Measures = new HashSet<Measure>();
            MusclesMeasures = new HashSet<MusclesMeasure>();
            Pagos = new HashSet<Pago>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Rol { get; set; } 
        public string Direccion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ExercisesMachine> ExercisesMachines { get; set; }
        public virtual ICollection<Measure> Measures { get; set; }
        public virtual ICollection<MusclesMeasure> MusclesMeasures { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
