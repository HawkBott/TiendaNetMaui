using Tienda.NetMaui.Modelo;

namespace Tienda.NetMaui.Paginas;

public partial class PorNombre : ContentPage
{
    Helper ?Sw;
    string ?nombreproducto;


	public PorNombre()
	{
		InitializeComponent();
        Producto.Items.Add("Coca Cola");
        Producto.Items.Add("Detergente (Roma)");
        Producto.Items.Add("Detergente (Salvo)");
        Producto.Items.Add("ItalPasta Spaghetti");
        Producto.Items.Add("Leche Condensada (La Lechera)");
        Producto.Items.Add("Leche Condensada (Pronto)");
        Producto.Items.Add("Sabritas");
    }

    private void Producto_SelectedIndexChanged(object sender, EventArgs e)
    {
        nombreproducto = Producto.SelectedItem.ToString();
    }

    private async void DatosPorProducto_Clicked(object sender, EventArgs e)
    {
        Sw = new Helper();

        if (Producto.SelectedItem != null)
        {
            List<Producto> DatosProductos = await Sw.ProductoPorNombre(nombreproducto);
            if (DatosProductos != null)
            {
                collectionView.ItemsSource = DatosProductos;
            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error al desplegar los datos", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Alert", "Seleccione un Producto", "Ok");
        }
    }
}