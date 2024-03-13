using Tienda.NetMaui.Modelo;

namespace Tienda.NetMaui.Paginas;

public partial class Listar : ContentPage
{
	Helper ?Sw;

	public Listar()
	{
		InitializeComponent();
	}

    private async void ObtenerDatos_Clicked(object sender, EventArgs e)
    {
		Sw = new Helper();
		List<Producto> DatosProductos = await Sw.ObtenerProductos();
		if (DatosProductos != null)
		{
			CollectionView.ItemsSource = DatosProductos;
		}
		else
		{
			await DisplayAlert("Error", "Ocurrió un error al desplegar los datos", "ok");
		}
    }
}