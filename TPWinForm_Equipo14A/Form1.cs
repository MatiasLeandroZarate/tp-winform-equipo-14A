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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ArticulosNegocio articuloNegocio = new ArticulosNegocio();
            dgvART.DataSource = articuloNegocio.listar();

        }
    }
}
