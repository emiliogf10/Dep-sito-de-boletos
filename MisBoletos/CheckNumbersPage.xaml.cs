namespace MisBoletos;

public partial class CheckRifaPage : ContentPage
{
    public CheckRifaPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var lista = await App.Database.GetAllAsync();

        if (lista.Count == 0)
        {
            lblEstado.Text = "Tu lista de boletos está vacía.";
            cvNumeros.ItemsSource = null;
        }
        else
        {
            lblEstado.Text = lblEstado.Text = lista.Count == 1 ? $"Tienes {lista.Count} boleto guardado" : $"Tienes {lista.Count} boletos guardados";
            cvNumeros.ItemsSource = lista;
        }
    }
}


