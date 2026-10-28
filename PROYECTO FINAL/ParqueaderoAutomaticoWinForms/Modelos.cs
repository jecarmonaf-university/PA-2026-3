namespace ParqueaderoAutomaticoWinForms;

public class EspacioParqueadero
{
    public int Numero { get; set; }
    public bool Ocupado { get; set; }
    public string Placa { get; set; } = "";
}

public class RegistroVehiculo
{
    public string Placa { get; set; } = "";
    public DateTime FechaEntrada { get; set; }
    public DateTime? FechaSalida { get; set; }
    public int Espacio { get; set; }
    public string Estado { get; set; } = "Ocupado";
    public decimal? TarifaAplicada { get; set; }

    public string HoraEntrada => FechaEntrada.ToString("HH:mm:ss");
    public string HoraSalida => FechaSalida?.ToString("HH:mm:ss") ?? "-";
    public string TarifaTexto => TarifaAplicada.HasValue
        ? TarifaAplicada.Value.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("es-CO"))
        : "-";
}

public class DatosSede
{
    public List<EspacioParqueadero> Espacios { get; } = new();
    public List<RegistroVehiculo> Registros { get; } = new();

    public DatosSede(int cantidadEspacios)
    {
        for (int i = 1; i <= cantidadEspacios; i++)
            Espacios.Add(new EspacioParqueadero { Numero = i });
    }
}
