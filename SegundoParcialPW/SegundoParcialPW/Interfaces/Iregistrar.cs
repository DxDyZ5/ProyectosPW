namespace SegundoParcialPW.Interfaces
{
    public interface Iregistrar
    {
        public void registrarIntercambio(DateTime fecha, string lugar);

        public void registrarCoordenada(int IdIntercambio, decimal latitud, decimal longitud);

        public void registrarParticipante(int? IdCoordenadas, string cedula, string nombre, string rol, string? estado);
    }
}
