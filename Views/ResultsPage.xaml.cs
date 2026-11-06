using RastreioEncomendas.ViewModels;

namespace RastreioEncomendas.Views;

public partial class ResultsPage : ContentPage
{
    public ResultsPage()
    {
        InitializeComponent();
        BindingContext = new ResultsViewModel();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
