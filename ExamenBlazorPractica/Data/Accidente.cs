public class Accidente
{
    public DateTime Fecha { get; set; } = DateTime.Today;
    public string Descripcion { get; set; } = "";
    public decimal CostoEconomico { get; set; }
    public int Muertos { get; set; }
    public int Heridos { get; set; }
    public int CantidadVehiculos { get; set; }
}
