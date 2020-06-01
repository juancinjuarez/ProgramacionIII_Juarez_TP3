using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Compra : System.Web.UI.Page
    {
        public Carrito carritos2 { get; set; }
        int cantArticulos;
        float precioTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recibo el articulo que agrego el usuario
            carritos2 = (Carrito)Session[Session.SessionID + "enviarArticulo"];

            //Muestro el articulo agregado
            if (!IsPostBack)
            {
                repeaterCompra.DataSource = carritos2.listaCarrito;
                repeaterCompra.DataBind();
                cantArticulos += carritos2.listaCarrito.Count;
                for (int i = 0; i < cantArticulos; i++)
                {
                    precioTotal += carritos2.listaCarrito[i].Precio;
                }
                lblPrecio.Text = "TOTAL: $" + precioTotal;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio arti = new ArticuloNegocio();
            Articulo artiDom = new Articulo();
            
            //Tomo el id del articulo que el usuario quiere eliminar
            string idArticulo2 = ((Button)sender).CommandArgument;
            
            //Elimino el articulo que pidio el usuario
            carritos2.listaCarrito.RemoveAt(carritos2.listaCarrito.FindIndex(J => J.Codigo == idArticulo2));
            //Actualizo la lista
            Session.Add(Session.SessionID + "enviarArticulo2", carritos2);
            
            //Recargo la pagina
            Response.Redirect("Compra.aspx");
        }
    }
}