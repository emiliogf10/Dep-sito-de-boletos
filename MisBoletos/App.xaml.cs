namespace MisBoletos;

public partial class App : Application
{

    // Lista accesible desde cualquier página
    public static List<int> Numeros { get; set; } = new();

    public App()
    {
        this.InitializeComponent();
        MainPage = new NavigationPage(new MainPage()); // Activamos navegación

    }
}