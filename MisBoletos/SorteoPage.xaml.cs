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
                lblResultado.Text = $"�El n�mero {n} est� en tu lista de boletos, enhorabuena!!";
            else
                lblResultado.Text = $"El n�mero {n} no est� en tu lista de boletos";
        }
        else
            lblResultado.Text = "Introduce un n�mero v�lido.";

        txtNumero.Text = ""; //Limpiar entrada de texto
    }
}