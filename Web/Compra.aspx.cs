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
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recibo el articulo que agrego el usuario
            carritos2 = (Carrito)Session[Session.SessionID + "enviarArticulo"];
                
            //Muestro el articulo agregado
            if (!IsPostBack)
            {
                repeaterCompra.DataSource = carritos2.listaCarrito;
                repeaterCompra.DataBind();
            }

        }
    }
}