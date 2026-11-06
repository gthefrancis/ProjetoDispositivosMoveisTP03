namespace RastreioEncomendas.Models;

public class TrackingEvent
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public string DateLabel => Date.ToString("dd/MM/yyyy 'às' HH:mm");
}
