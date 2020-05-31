using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP2_JuarezJuanManuel
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {   
            CategoriaNegocio cat = new CategoriaNegocio();
            try
            {
                cbxCategoria.DataSource = cat.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MarcaNegocio marca = new MarcaNegocio();
            try
            {
                cbxMarca.DataSource = marca.listar();
            }
            catch (Exception ex2)
            {

                MessageBox.Show(ex2.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                nuevo.Codigo = txtCodigo.Text.Trim();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Descripcion = txtDescripcion.Text.Trim();
                nuevo.Marca = (MarcaDominio)cbxMarca.SelectedItem;
                nuevo.Categoria = (CategoriaDominio)cbxCategoria.SelectedItem;
                nuevo.ImagenURL = txtImagen.Text.Trim();
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                negocio.agregar(nuevo); 

                Dispose();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
