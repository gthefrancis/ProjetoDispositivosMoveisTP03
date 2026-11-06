using RastreioEncomendas.Models;

namespace RastreioEncomendas.Services;

/// <summary>
/// Serviço demonstrativo. Substitua este serviço por uma integração HTTP
/// com a transportadora quando houver uma API real disponível.
/// </summary>
public class TrackingService : ITrackingService
{
    public async Task<Package?> GetPackageAsync(string trackingCode)
    {
        await Task.Delay(900); // Simula o tempo de consulta à transportadora.

        if (string.IsNullOrWhiteSpace(trackingCode))
            return null;

        var now = DateTime.Now;
        return new Package
        {
            PackageId = trackingCode.Trim().ToUpperInvariant(),
            Status = "Em trânsito",
            ShippingDate = now.Date.AddDays(-3),
            EstimatedDeliveryDate = now.Date.AddDays(2),
            CurrentLocation = "Centro de distribuição - São Paulo/SP",
            Events = new List<TrackingEvent>
            {
                new()
                {
                    Date = now.AddHours(-2),
                    Description = "Objeto encaminhado para a unidade de distribuição",
                    Location = "São Paulo/SP"
                },
                new()
                {
                    Date = now.AddDays(-1),
                    Description = "Objeto recebido pela transportadora",
                    Location = "Campinas/SP"
                },
                new()
                {
                    Date = now.Date.AddDays(-3).AddHours(10),
                    Description = "Objeto postado",
                    Location = "Santos/SP"
                }
            }
        };
    }
}
