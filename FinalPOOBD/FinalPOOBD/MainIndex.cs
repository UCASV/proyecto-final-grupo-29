using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalPOOBD
{
    public partial class MainIndex : Form
    {
        public MainIndex()
        {
            InitializeComponent();
        }

        private void MainIndex_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var MainFRM = new Login();
            MainFRM.Show();
            Hide();
        }

        private void iniciarProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Vacunacion = new Vacunacion();
            Vacunacion.Show();
        }

        private void MainIndex_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
        }

        private void crearFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FORM = new Formulario();
            FORM.ShowDialog();
        }

        private void seguimientoDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
