namespace MisBoletos;

public partial class RemoveRifaPage : ContentPage
{
	public RemoveRifaPage()
	{
		InitializeComponent();
        BindingContext = App.Numeros;
    }

    // Eliminar los seleccionados
    private void OnEliminarSeleccionadosClick(object sender, EventArgs e)
    {
        var seleccionados = cvNumeros.SelectedItems.Cast<int>().ToList();

        if (seleccionados.Count == 0)
        {
            lblMensaje.Text = "No seleccionaste ningún número.";
            return;
        }

        foreach (var n in seleccionados)
            App.Numeros.Remove(n);


        lblMensaje.Text = seleccionados.Count > 1 ? $"Se eliminaron {seleccionados.Count} boletos." : $"Se eliminó {seleccionados.Count} boleto";

        cvNumeros.SelectedItems.Clear(); // limpiar selección
        cvNumeros.ItemsSource = null;
        cvNumeros.ItemsSource = App.Numeros; // refrescar la lista
    }

    // Eliminar todos
    private void OnEliminarTodosClick(object sender, EventArgs e)
    {
        if (App.Numeros.Count == 0)
        {
            lblMensaje.Text = "La lista ya está vacía.";
            return;
        }

        App.Numeros.Clear();
        lblMensaje.Text = "Se eliminaron todos los números.";
        cvNumeros.ItemsSource = null;
        cvNumeros.ItemsSource = App.Numeros; // refrescar
    }
}