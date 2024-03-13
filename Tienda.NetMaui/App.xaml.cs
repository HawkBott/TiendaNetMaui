namespace Tienda.NetMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PrincipalPestañas();
        }
    }
}
