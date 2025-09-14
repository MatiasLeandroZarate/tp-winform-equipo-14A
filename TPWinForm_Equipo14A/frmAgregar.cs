using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_Equipo14A
{
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            ///Menu Desplegable de Marca
            cboMarca.Items.Add("Samsung");
            cboMarca.Items.Add("Sony");
            cboMarca.Items.Add("Apple");
            cboMarca.Items.Add("Huawei");
            cboMarca.Items.Add("Motorola");

            ///Menu Desplegable de Categoría
            cboCategoria.Items.Add("Celulares");
            cboCategoria.Items.Add("Media");
            cboCategoria.Items.Add("Televisores");
            cboCategoria.Items.Add("Audio");
        }
    }
}
