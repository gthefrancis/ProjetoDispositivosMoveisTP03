using RastreioEncomendas.Models;

namespace RastreioEncomendas.Services;

public interface ITrackingService
{
    Task<Package?> GetPackageAsync(string trackingCode);
}
