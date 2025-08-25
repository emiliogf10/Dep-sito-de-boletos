namespace MisBoletos;

public partial class CheckNumbersPage : ContentPage
{
	public CheckNumbersPage()
	{
		InitializeComponent();
        ActualizarVista(); // Pasamos la lista directamente
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActualizarVista(); // refrescar cada vez que entres en la página
    }

    private void ActualizarVista()
    {
        if (App.Numeros.Count == 0)
        {
            lblEstado.Text = "Tu lista de boletos está vacía";
            cvNumeros.ItemsSource = null;
        }
        else
        {
            lblEstado.Text = $"Tienes {App.Numeros.Count} boletos guardados:";
            cvNumeros.ItemsSource = null;
            cvNumeros.ItemsSource = App.Numeros;
        }
    }
}