using Tienda.NetMaui.Modelo;

namespace Tienda.NetMaui.Paginas;

public partial class ListarImg : ContentPage
{
    Helper? Sw;
    public ListarImg()
    {
        InitializeComponent();
    }

    private async void ObtenerDatosImg_Clicked(object sender, EventArgs e)
    {
        Sw = new Helper();
        List<Producto> DatosProductos = await Sw.ObtenerProductos();
        if (DatosProductos != null)
        {
            collectionView.ItemsSource = DatosProductos;
        }
        else
        {
            await DisplayAlert("Error", "Ocurrió un error al desplegar los datos", "Ok");
        }
    }
}