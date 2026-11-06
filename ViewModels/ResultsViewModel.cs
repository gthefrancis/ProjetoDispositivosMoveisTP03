using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using RastreioEncomendas.Models;
using RastreioEncomendas.Services;

namespace RastreioEncomendas.ViewModels;

public class ResultsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly ITrackingService _trackingService;
    private string _trackingCode = string.Empty;
    private Package? _package;
    private bool _isBusy;
    private string _errorMessage = string.Empty;

    public ResultsViewModel()
    {
        _trackingService = new TrackingService();
        Events = new ObservableCollection<TrackingEvent>();
    }

    public string TrackingCode
    {
        get => _trackingCode;
        set
        {
            if (SetProperty(ref _trackingCode, Uri.UnescapeDataString(value ?? string.Empty)))
                _ = LoadPackageAsync();
        }
    }

    public Package? Package
    {
        get => _package;
        set => SetProperty(ref _package, value);
    }

    public ObservableCollection<TrackingEvent> Events { get; }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool HasPackage => Package is not null;
    public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("trackingCode", out var value))
            TrackingCode = value?.ToString() ?? string.Empty;
    }

    private async Task LoadPackageAsync()
    {
        if (string.IsNullOrWhiteSpace(TrackingCode)) return;

        IsBusy = true;
        ErrorMessage = string.Empty;
        Package = null;
        Events.Clear();
        OnPropertyChanged(nameof(HasPackage));
        OnPropertyChanged(nameof(HasError));

        try
        {
            Package = await _trackingService.GetPackageAsync(TrackingCode);
            if (Package is null)
                ErrorMessage = "Não encontramos informações para esse código.";

            if (Package is not null)
                foreach (var item in Package.Events)
                    Events.Add(item);
        }
        catch
        {
            ErrorMessage = "Ocorreu um erro ao consultar o pacote. Tente novamente.";
        }
        finally
        {
            IsBusy = false;
            OnPropertyChanged(nameof(HasPackage));
            OnPropertyChanged(nameof(HasError));
        }
    }
}
