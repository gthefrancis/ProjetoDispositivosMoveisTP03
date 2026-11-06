using System.Windows.Input;

namespace RastreioEncomendas.ViewModels;

public class TrackingViewModel : BaseViewModel
{
    private string _trackingCode = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isBusy;

    public TrackingViewModel()
    {
        SearchCommand = new AsyncCommand(SearchAsync, () =>
            !string.IsNullOrWhiteSpace(TrackingCode) && !IsBusy);
    }

    public string TrackingCode
    {
        get => _trackingCode;
        set
        {
            if (SetProperty(ref _trackingCode, value))
                (SearchCommand as AsyncCommand)?.NotifyCanExecuteChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
                (SearchCommand as AsyncCommand)?.NotifyCanExecuteChanged();
        }
    }

    public ICommand SearchCommand { get; }

    private async Task SearchAsync()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(TrackingCode))
        {
            ErrorMessage = "Digite um código de rastreamento.";
            return;
        }

        IsBusy = true;
        try
        {
            var code = Uri.EscapeDataString(TrackingCode.Trim());
            await Shell.Current.GoToAsync($"{nameof(RastreioEncomendas.Views.ResultsPage)}?trackingCode={code}");
        }
        catch (Exception)
        {
            ErrorMessage = "Não foi possível abrir a consulta. Tente novamente.";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
