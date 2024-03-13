using Newtonsoft.Json;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.NetMaui.Modelo
{
    public class Helper
    {
        readonly HttpClient Cliente;
        List<Producto> ?DatosProductos = [];
        public Helper()
        {
            Cliente = new HttpClient();
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                ("application/Json"));
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            string Contenido;
            const string URI = "http://192.168.1.64/Tienda/api/Productos/ListaProductos/";

            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta = respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    DatosProductos = JsonConvert.DeserializeObject<List<Producto>>(Contenido);
                }
            }
            catch (HttpRequestException)
            {
                Producto Pr = new Producto()
                {
                    Nombre = "Ha ocurrido un problema al desplegar los datos",
                };
                DatosProductos.Add(Pr);
            }
            return DatosProductos;
        }


        public async Task<List<Producto>> ProductoPorNombre(string nombre)
        {
            string Contenido;
            string URI = "http://192.168.1.64/Tienda/api/Productos/ProductoPorNombre/" + nombre;

            try
            {
                HttpResponseMessage respuesta = await Cliente.GetAsync(URI);
                respuesta = respuesta.EnsureSuccessStatusCode();

                if (respuesta.IsSuccessStatusCode)
                {
                    Contenido = await respuesta.Content.ReadAsStringAsync();
                    DatosProductos = JsonConvert.DeserializeObject<List<Producto>>(Contenido);
                }
            }
            catch (HttpRequestException)
            {
                Producto Pr = new Producto
                {
                    Nombre = "Haocurrido un problema al desplegar los datos",
                };
                DatosProductos.Add(Pr);
            }
            return DatosProductos;
        }
    }
}
