using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio_sesion
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            var db = new FinalProjectPOO_DBContext();
            int typeEmployee = 2;
            string textManager = txtManagerid.Text;
            var cabinP = int.Parse(cmbCabin.SelectedValue.ToString());
            var employeeP = int.Parse(txtManagerid.Text);
            var listuser = db.Employee.Include(c => c.id).ToList();
            var result = listuser.Where(u => u.Nickname.Equals(txtUser.Text) && u.password.Equals(txtPassword.Text)).ToList();
            DateTime td = DateTime.Now;
            if (result.Count > 0)
            {
                var user = db.Employee.Where(c => c.Nickname == txtUser.Text).Include(c => c.id).ToList();
                MessageBox.Show($"Bienvenido {textUser}!", "Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Logs Asesion = new Logs()
                {
                    IdCabin = cabinP,
                    IdEmployee = employeeP,
                    TimeDate = td
                };
                db.Add(Logs);
                db.SaveChanges();

                Form window = new Form2(user[0]);
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: Usuario no encontrado", "Vacunación Covid-19", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.ShowDialog();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            var db = new FinalProjectPOO_DBContext();
            List<Cabin> cmbCabin.DataSource = db.Cabins.ToList();
            cmbCabin.DisplayMember = "Direccion;
            cmbCabin.ValueMember = "Id";
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
