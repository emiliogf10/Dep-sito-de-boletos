namespace MisBoletos;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAddClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new AddRifPage());

    private async void OnRemoveClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new RemoveRifaPage());

    private async void OnCheckClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new CheckRifaPage());

    private async void OnSorteoClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new SorteoPage());
}
