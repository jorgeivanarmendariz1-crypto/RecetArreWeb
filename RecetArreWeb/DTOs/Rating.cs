namespace RecetArreWeb.DTOs
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Estrellas { get; set; }
        public DateTime CreadoUtc { get; set; }
        public string SemanaAno { get; set; } = string.Empty;
        public int RecetaId { get; set; }
        public string UsuarioId { get; set; } = string.Empty;
    }

    public class RatingCreacionDto
    {
        public int RecetaId { get; set; }
        public int Estrellas { get; set; }
    }

    public class RatingResumenDto
    {
        public int RecetaId { get; set; }
        public double Promedio { get; set; }
        public int TotalVotos { get; set; }
        public string SemanaAno { get; set; } = string.Empty;
        public int? VotoUsuarioActual { get; set; }
    }

    public class PowerRankingItemDto
    {
        public int Posicion { get; set; }
        public int RecetaId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public double Promedio { get; set; }
        public int TotalVotos { get; set; }
        public string AutorId { get; set; } = string.Empty;
    }
}