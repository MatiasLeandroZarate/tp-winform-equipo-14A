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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "ID";
                cboMarca.DisplayMember = "DescripcionMarca";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "ID";
                cboCategoria.DisplayMember = "DescripcionCategoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulos nuevo = new Articulos();
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {
                nuevo.CodigoArticulo = txtCodArt.Text;
                nuevo.Nombre = txtNombreArt.Text;
                nuevo.Marca.ID = (int)cboMarca.SelectedValue;
                nuevo.Categoria.ID = (int)cboCategoria.SelectedValue;
                nuevo.UrlImagen = txtURLImagen.Text;
                nuevo.DescripcionART = txtDescArt.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                negocio.Agregar(nuevo);
                MessageBox.Show("Agregado Exitosamente");
                Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
