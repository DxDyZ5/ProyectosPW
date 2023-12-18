namespace IntercambioDisparoPW.DTOS
{
    public class IntercambioDTO
    {
        public int IdIntercambio { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = null!;
    }
}
