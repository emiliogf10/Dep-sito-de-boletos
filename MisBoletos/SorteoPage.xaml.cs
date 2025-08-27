namespace MisBoletos;

public partial class SorteoPage : ContentPage
{
    public SorteoPage()
    {
        InitializeComponent();
    }

    private async void OnCheckClick(object sender, EventArgs e)
    {
        if (!int.TryParse(txtNumero.Text, out int n))
        {
            lblResultado.Text = "Introduce un número válido.";
            return;
        }

        var encontrado = await App.Database.GetByNumeroAsync(n);
        if (encontrado != null)
            lblResultado.Text = $"¡El número {n} es tuyo!";
        else
            lblResultado.Text = $"El número {n} no está en tu lista de boletos";
    }
}
