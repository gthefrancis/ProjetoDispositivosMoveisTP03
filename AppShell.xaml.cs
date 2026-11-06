using RastreioEncomendas.Views;

namespace RastreioEncomendas;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
    }
}
