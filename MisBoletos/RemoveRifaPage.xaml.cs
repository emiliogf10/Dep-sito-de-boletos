using System;
using System.Linq;
using Microsoft.Maui.Controls;
using MisBoletos.Models;

namespace MisBoletos;

public partial class RemoveRifaPage : ContentPage
{
    public RemoveRifaPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await RecargarListaAsync();
    }

    private async System.Threading.Tasks.Task RecargarListaAsync()
    {
        var lista = await App.Database.GetAllAsync();

        cvNumeros.ItemsSource = lista;

        if (lista.Count == 0)
        {
            lblTitulo.Text = "No hay nada para eliminar";
            cvNumeros.IsVisible = false;
        }
        else
        {
            lblTitulo.Text = "Selecciona los números que quieras eliminar";
            cvNumeros.IsVisible = true;
        }

        lblMensaje.Text = "";
    }

    private async void OnEliminarSeleccionadosClick(object sender, EventArgs e)
    {
        var seleccionados = cvNumeros.SelectedItems?.Cast<Boleto>().ToList() ?? new();

        if (seleccionados.Count == 0)
        {
            lblMensaje.Text = "No seleccionaste ningún número.";
            return;
        }

        foreach (var b in seleccionados)
            await App.Database.DeleteAsync(b);

        lblMensaje.Text = seleccionados.Count > 1
            ? $"Se eliminaron {seleccionados.Count} boletos."
            : $"Se eliminó {seleccionados.Count} boleto";

        cvNumeros.SelectedItems.Clear();
        await RecargarListaAsync();
    }

    private async void OnEliminarTodosClick(object sender, EventArgs e)
    {
        var lista = await App.Database.GetAllAsync();
        if (lista.Count == 0)
        {
            lblMensaje.Text = "La lista ya está vacía.";
            return;
        }

        bool respuesta = await DisplayAlert("Confirmar", "¿Deseas eliminar todos los boletos?", "Sí", "No");
        if (!respuesta) return;

        await App.Database.DeleteAllAsync();
        lblMensaje.Text = "Se eliminaron todos los números.";
        await RecargarListaAsync();
    }
}



