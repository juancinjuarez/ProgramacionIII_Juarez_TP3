using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_JuarezJuanManuel
{
    public partial class frmListarArticulos : Form
    {
        public frmListarArticulos()
        {
            InitializeComponent();
        }

        private void frmListarArticulos_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulo.DataSource = negocio.listar();

            //dgvArticulo.Columns[0].Visible = false;
            //dgvArticulo.Columns[1].Visible = false;
            //dgvArticulo.Columns[2].Visible = false;
            //dgvArticulo.Columns[3].Visible = false;
            //dgvArticulo.Columns[4].Visible = false;
            //dgvArticulo.Columns[5].Visible = false;
            //dgvArticulo.Columns[6].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pcbImagen_Click(object sender, EventArgs e)
        {

        }

        private void dgvArticulo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                pcbImagen.Load(art.ImagenURL);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulo art;
                art = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                pcbImagen.Load(art.ImagenURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
