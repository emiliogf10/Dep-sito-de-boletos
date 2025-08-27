namespace MisBoletos;

public partial class AddRifPage : ContentPage
{
	public AddRifPage()
	{
		InitializeComponent();
	}

    private async void OnAddClick(object sender, EventArgs e)
    {
        if (int.TryParse(txtNumero.Text, out int n))
        {
            var inserted = await App.Database.InsertIfNotExistsAsync(n);
            if (inserted > 0)
            {
                lblMensaje.Text = $"N�mero {n} a�adido correctamente a la lista de boletos";
                txtNumero.Text = string.Empty;
            }
            else
            {
                lblMensaje.Text = $"El n�mero {n} ya existe en la lista de boletos";
            }
        }
        else
        {
            lblMensaje.Text = "Introduce un n�mero v�lido.";
        }
    }
}