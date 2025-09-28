namespace DailyWellnessPro;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Wrap MainPage in NavigationPage to enable stack navigation
        MainPage = new NavigationPage(new MainPage());
    }
}