using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Procedo_de_cita.databaseContext;
using System.Text.RegularExpressions;

namespace Procedo_de_cita
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblnombre_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void bttnAccept_Click(object sender, EventArgs e)
        {
            var expression = "^[0-9]{9}$";
            string text = txtbDUI.Text;
            var db = new FinalProjectPOO_DBContext();
            var listCitizen = db.Citizens.Where(c => c.Dui.Equals(text)).ToList();
            if (Regex.IsMatch(text, expression))
            {
                if (txtbName.Text.Length > 5 && txtbAddress.Text.Length > 5 && txtbPhone.Text.Length > 5)
                {
                    if (listCitizen.Count == 0)
                    {
                        Institution choice = new Institution();
                        choice.Id = ((Institution)cmbIntitution.SelectedItem).Id;
                        Institution dbinstitution = db.Set<Institution>().SingleOrDefault(inst => inst.Id == choice.Id);

                        var citizen = new Citizen();

                        citizen.Dui = txtbDUI.Text;
                        citizen.Name = txtbName.Text;
                        citizen.Address = txtbAddress.Text;
                        citizen.Phone = Convert.ToInt32(txtbPhone.Text);
                        citizen.Email = txtbEmail.Text;
                        citizen.Birthday = dtpBirthDay.Value.Date;
                        citizen.IdAppointment1 = null;
                        citizen.IdInstitution = dbinstitution.Id;
                
                        var appointment = new Appointment();
                        var rand = new Random();
                        int n;
                        n = rand.Next(3, 10);
                        var date = DateTime.Now.Date;
                        date = date.AddDays(n);
                        n = rand.Next(5, 17);
                        date = date.AddHours(n);
                        appointment.TimeDate = date;
                        n = rand.Next(1, db.Cabins.Count());
                        appointment.IdCabinAppointment1 = n;
                        db.Add(appointment);
                        db.SaveChanges();
                        int idAppointment = db.Appointments.OrderBy(c => c.IdAppointment1).Last().IdAppointment1;
                        citizen.IdAppointment1 = idAppointment;
                        db.Add(citizen);
                        db.SaveChanges();

                        MessageBox.Show("Ciudadano Ingresado.", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR Dui duplicado!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR Digite mas de 5 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ERROR Dui erroneo ejemplo : '000000000'", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var db = new FinalProjectPOO_DBContext();
            var institution = db.Institutions.ToList();
            cmbIntitution.DataSource = institution;
            cmbIntitution.ValueMember = "Id";
            cmbIntitution.DisplayMember = "Institution1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtbDisease.Text.Length > 5)
            {
              cblDisease.Items.Add(txtbDisease.Text);
            }
            else
            {
             MessageBox.Show("ERROR Digite mas de 5 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
