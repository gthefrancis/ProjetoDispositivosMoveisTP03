using RastreioEncomendas.ViewModels;

namespace RastreioEncomendas.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new TrackingViewModel();
    }
}
