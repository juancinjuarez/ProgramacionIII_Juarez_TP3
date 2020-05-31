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
    public partial class frmModificarArticulo : Form
    {
        public frmModificarArticulo()
        {
            InitializeComponent();
        }

        private void frmModificarArticulo_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articulo.Codigo = txtCodigo.Text.Trim();
                articulo.Nombre = txtNombre.Text.Trim();
                articulo.Descripcion = txtDescripcion.Text.Trim();
                articulo.Marca = (MarcaDominio)cbxMarca.SelectedItem;
                articulo.Categoria = (CategoriaDominio)cbxCategoria.SelectedItem;
                articulo.ImagenURL = txtImagen.Text.Trim();
                articulo.Precio = (decimal)double.Parse(txtPrecio.Text);

                negocio.modificar(articulo);

                Dispose();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
