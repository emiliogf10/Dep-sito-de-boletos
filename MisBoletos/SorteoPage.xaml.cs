namespace MisBoletos;

public partial class SorteoPage : ContentPage
{
	public SorteoPage()
	{
		InitializeComponent();
	}

    private void OnCheckClick(object sender, EventArgs e)
    {
        if (int.TryParse(txtNumero.Text, out int n))
        {
            if (App.Numeros.Contains(n))
                lblResultado.Text = $"¡El número {n} está en tu lista de boletos, enhorabuena!!";
            else
                lblResultado.Text = $"El número {n} no está en tu lista de boletos";
        }
        else
            lblResultado.Text = "Introduce un número válido.";

        txtNumero.Text = ""; //Limpiar entrada de texto
    }
}