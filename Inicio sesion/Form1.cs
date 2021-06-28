using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inicio_sesion.databaseContext;
using Microsoft.EntityFrameworkCore;

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
            var listuser = db.Employees.Where(e=> e.IdTypeEmployee.Equals(2)).ToList();
            var result = listuser.Where(u => u.Nickname.Equals(txtUser.Text)).ToList();

            Cabin choice = new Cabin();
            choice.Id = ((Cabin)cmbCabins.SelectedItem).Id;
            Cabin dbcabin= db.Set<Cabin>().SingleOrDefault(inst => inst.Id == choice.Id);
            if (result.Count > 0)
            {
                if (Convert.ToString(txtPassword.Text) == result.First().Password)
                {


                    var user = result.First();
                MessageBox.Show($"Bienvenido {user.Name}!", "Vacunación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Log Asesion = new Log()
                {
                    IdCabin = dbcabin.Id,
                    IdEmployee = result[0].Id,
                    TimeDate = DateTime.Now
                };
                db.Add(Asesion);
                db.SaveChanges();

                /*Form window = new Form(user[0]);*///mandar a siguiente formulario
                //window.Show();
                //this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: Contraseña errónea", "Vacunación Covid-19", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
            var db = new FinalProjectPOO_DBContext();
            var cabins = db.Cabins.ToList();
            cmbCabins.DataSource = cabins;
            cmbCabins.ValueMember = "Id";
            cmbCabins.DisplayMember = "Address";
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
