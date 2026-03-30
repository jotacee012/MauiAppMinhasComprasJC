namespace MauiAppMinhasComprasJC;

public partial class App : Application
{
    public static Database Db { get; private set; }

    public App()
    {
        InitializeComponent();

        Db = new Database();
        MainPage = new AppShell();
    }
}