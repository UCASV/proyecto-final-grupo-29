using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalPOOBD.databaseContext;

namespace FinalPOOBD
{
    public partial class Login : Form
    {
        private Employee person { get; set; }
        private Cabin place { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                comboBox1.DataSource = db.Cabins.ToList();
                comboBox1.DisplayMember = "address";
                comboBox1.ValueMember = "id";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                var employeeList = db.Employees
                    .ToList();
                var newList = new List<Employee>();
                for (int i = 0; i < employeeList.Count(); i++)
                {
                    if (employeeList[i].Nickname != null && employeeList[i].Nickname == textBox1.Text)
                    {
                        newList.Add(employeeList[i]);
                    }
                }

                if (!newList.Any())
                {
                    MessageBox.Show(
                        "Lo siento, pero no pudimos encontrar el usuario ingresado. Revisa los datos y vuelve a intentarlo",
                        "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    person = newList.First();
                    if (textBox2.Text != person.Password)
                    {
                        MessageBox.Show(
                            "Contraseña incorrecta. Revisa los datos y vuelve a intentarlo",
                            "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var MainFRM = new MainIndex();
                        place = db.Cabins.ToList().Where(c => c.Id.Equals(comboBox1.SelectedValue)).First();
                        db.Logs.Add(createLog(person, place));
                        MainFRM.Show();
                        Hide();
                    }
                }
                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private Log createLog(Employee e, Cabin c)
        {
            var Logg = new Log();
            Logg.IdCabin = c.Id;
            Logg.IdEmployee = e.Id;
            Logg.TimeDate = DateTime.Now;
            return Logg;
        }
    }
}
