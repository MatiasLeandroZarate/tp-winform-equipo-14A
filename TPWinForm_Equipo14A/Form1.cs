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
    public partial class Form1 : Form
    {
        private List<Articulos> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ArticulosNegocio articuloNegocio = new ArticulosNegocio();
            //listaArticulos = articuloNegocio.listar();
            listaArticulos = articuloNegocio.VerDetalle();
            dgvART.DataSource = listaArticulos;
            dgvART.Columns[6].Visible = false;
            cargarImagen(listaArticulos[0].UrlImagen);

        }

        private void dgvART_SelectionChanged(object sender, EventArgs e)
        {
            Articulos seleccionado = (Articulos) dgvART.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbx.Load(imagen);
            }
            catch (Exception)
            {
                pbx.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
