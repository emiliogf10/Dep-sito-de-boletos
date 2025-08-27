using MisBoletos.Data;
using System.IO;
using Microsoft.Maui.Storage;


namespace MisBoletos;

public partial class App : Application
{

    // Lista accesible desde cualquier página
    public static List<int> Numeros { get; set; } = new();

    private static BoletoDataBase? database;

    public static BoletoDataBase Database
    {
        get
        {
            if (database == null)
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "boletos.db3");
                database = new BoletoDataBase(dbPath);
            }
            return database;
        }
    }

    public App()
    {
        this.InitializeComponent();
        MainPage = new NavigationPage(new MainPage()); // Activamos navegación

    }
}