namespace SmartFit_API.Models.DTOs
{
    public class MusclesMeasureDTO
    {

        public int IdMuscle { get; set; }
        public int IdUsuario { get; set; }
        public string Musculo { get; set; } = null!;
        public decimal Medida { get; set; }
        public DateTime FechaMedida { get; set; }
    }
}
