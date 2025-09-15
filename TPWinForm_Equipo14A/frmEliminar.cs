using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinForm_Equipo14A
{
    public partial class frmEliminar : Form
    {
        private List<Articulos> listaArticulos;
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                ArticulosNegocio articuloNegocio = new ArticulosNegocio();
                listaArticulos = articuloNegocio.listar();
                dgvEliminar.DataSource = listaArticulos;
                dgvEliminar.Columns[4].Visible = false;
                dgvEliminar.Columns[5].Visible = false;
                dgvEliminar.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
           Eliminar();
        }
        private void btnLogico_Click(object sender, EventArgs e)
        {
            Eliminar(true);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {
            cargar();
            
        }

        private void Eliminar( bool logico = false)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            Articulos seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea eliminar el artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulos)dgvEliminar.CurrentRow.DataBoundItem;
                    if(logico)
                        MessageBox.Show("Eliminación lógica no implementada");
                    // negocio.EliminarLogico(seleccionado.ID);
                    else
                        negocio.EliminarDB(seleccionado.ID);
                    cargar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
