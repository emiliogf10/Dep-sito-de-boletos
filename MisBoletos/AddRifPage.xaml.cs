namespace MisBoletos;

public partial class AddRifPage : ContentPage
{
	public AddRifPage()
	{
		InitializeComponent();
	}

    private void OnAddClick(object sender, EventArgs e)
    {
        if (int.TryParse(txtNumero.Text, out int n))
        {
            if (!App.Numeros.Contains(n))
            {
                App.Numeros.Add(n);
                lblMensaje.Text = $"N�mero {n} a�adido a la lista de boletos.";
                txtNumero.Text = "";
            }
            else
                lblMensaje.Text = $"El n�mero {n} ya existe.";
        }
        else
            lblMensaje.Text = "Introduce un n�mero v�lido.";
    }
}