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
    public partial class frmLista : Form
    {
        private List<Articulos> listaArticulos;
        public frmLista()
        {
            InitializeComponent();
        }

       
        private void frmLista_Load(object sender, EventArgs e)
        {
            ArticulosNegocio articuloNegocio = new ArticulosNegocio();
            listaArticulos = articuloNegocio.VerDetalle();
            dgvART.DataSource = listaArticulos;
            dgvART.Columns[6].Visible = false;
            cargarImagen(listaArticulos[0].UrlImagen);
        }

        private void dgvART_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvART.CurrentRow != null)
            {
                Articulos seleccionado = (Articulos)dgvART.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
            
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
        
        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {
         Filtrar();
        }

        private void tbxMarca_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void Filtrar()
        {
            List<Articulos> listaFiltrada;

            if (tbxMarca.Text != "" && tbxNombre.Text == "")
            {
                listaFiltrada = listaArticulos.FindAll(marca => marca.Marca.DescripcionMarca.ToUpper().Contains(tbxMarca.Text.ToUpper()));
            }
            else if (tbxMarca.Text == "" && tbxNombre.Text != "")
            {
                listaFiltrada = listaArticulos.FindAll(id => id.Nombre.ToUpper().Contains(tbxNombre.Text.ToUpper()));
            }
            else if (tbxMarca.Text != "" && tbxNombre.Text != "")
            {
                listaFiltrada = listaArticulos.FindAll(marca => marca.Marca.DescripcionMarca.ToUpper().Contains(tbxMarca.Text.ToUpper()) && marca.Nombre.ToUpper().Contains(tbxNombre.Text.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvART.DataSource = null;
            dgvART.DataSource = listaFiltrada;
            dgvART.Columns[6].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado;
            seleccionado = (Articulos)dgvART.CurrentRow.DataBoundItem;

            frmModificar ventana = new frmModificar(seleccionado);
            ventana.ShowDialog();
        }
    }
}
