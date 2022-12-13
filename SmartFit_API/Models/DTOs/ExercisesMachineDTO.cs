namespace SmartFit_API.Models.DTOs
{
    public class ExercisesMachineDTO
    {
        public int IdEjercicio { get; set; }
        public int IdUsuario { get; set; }
        public string NameExercise { get; set; } = null!;
        public int Peso { get; set; }
        public string CantidadRepeticiones { get; set; } = null!;
        public string Tiempo { get; set; } = null!;
    }
}
