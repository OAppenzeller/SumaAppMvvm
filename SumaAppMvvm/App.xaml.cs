namespace SumaAppMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(root: new Views.MainPage());
        }
    }
}