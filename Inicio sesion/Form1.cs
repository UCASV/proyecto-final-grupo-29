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
            string usuario = txtUser.Text;
            string contraseña = txtPassword.Text;

            var db = new FinalProjectPOO_DBContext();
            var listuser = db.Employee.Include(c => c.id).ToList();
            var result = listuser.Where(u => u.Nickname.Equals(txtUser.Text) && u.password.Equals(txtPassword.Text)).ToList();

            if (result.Count > 0)
            {
                var user = db.Employee.Where(c => c.Nickname == txtUser.Text).Include(c => c.id).ToList();
                MessageBox.Show($"Bienvenido {textUser}!", "Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Logs Asesion = new Logs()
                {
                    IdCabin = 1,
                    IdManager = result[0].Id,
                    td = time_date.Now
                };
                db.Add(Asesion);
                db.SaveChanges();

                Form window = new Form(user[0]);//mandar a siguiente formulario
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
            this.Close();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
