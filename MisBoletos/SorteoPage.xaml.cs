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
            lblResultado.Text = "Introduce un n�mero v�lido.";
            return;
        }

        var encontrado = await App.Database.GetByNumeroAsync(n);
        if (encontrado != null)
            lblResultado.Text = $"�El n�mero {n} es tuyo!";
        else
            lblResultado.Text = $"El n�mero {n} no est� en tu lista de boletos";
    }
}
