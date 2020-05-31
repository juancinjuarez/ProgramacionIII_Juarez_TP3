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
    public partial class frmBusquedaArticulo : Form
    {
        public frmBusquedaArticulo()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articulo.Codigo = txtBusquedaCodigo.Text.Trim();
                negocio.buscar(articulo);

                Dispose();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                pcbImagen.Load(art.ImagenURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pcbImagen_Click(object sender, EventArgs e)
        {

        }

        private void frmBusquedaArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar();

            //dgvArticulo.Columns[0].Visible = false;
            //dgvArticulo.Columns[1].Visible = false;
            //dgvArticulo.Columns[2].Visible = false;
            //dgvArticulo.Columns[3].Visible = false;
            //dgvArticulo.Columns[4].Visible = false;
            //dgvArticulo.Columns[5].Visible = false;
            //dgvArticulo.Columns[6].Visible = false;
        }

        private void txtBusquedaCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
