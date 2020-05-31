using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Web
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public Carrito car = new Carrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                listaArticulos = articulo.listar();
                articulosRepeater.DataSource = listaArticulos;
                articulosRepeater.DataBind();
            }
        }
        //Agrega articulo al carrito
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            //Creo un nuevo articulo negocio
            ArticuloNegocio arti = new ArticuloNegocio();
            //Recibo el id del articulo pasado por el boton 
            string idArticulo = ((Button)sender).CommandArgument;
            //Creo un nuevo articulo
            Articulo articulo = new Articulo();

            //Busco el articulo con el id que recibo del boton
            articulo = arti.buscarPorCodigo(idArticulo);
            //Agrego el articulo a la lista del carrito
            car.listaCarrito.Add(articulo);
            //Cuenta las veces que se agrego un articulo(las veces que se hizo clic en agregar un mismo articulo)
            car.listaCarrito.Count();

            //Envio la lista a la segunda pantalla
            Session.Add(Session.SessionID + "enviarArticulo", car);
        }
        //Redirecciona a la pagina del carrito
        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compra.aspx");
        }
    }
}