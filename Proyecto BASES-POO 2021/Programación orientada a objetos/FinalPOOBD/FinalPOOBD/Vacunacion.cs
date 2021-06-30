using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using FinalPOOBD.databaseContext;

namespace FinalPOOBD
{
    public partial class Vacunacion : Form
    {
        private int SEG { get; set; }
        private int MIN { get; set; }
        private Citizen Sujeto { get; set; }
        private Appointment Cita { get; set; }
        public Vacunacion()
        {
            InitializeComponent();
        }

        private void Vacunacion_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(0, 1);
            checkedListBox1.CheckOnClick = true;
            using (var db = new FinalProjectPOO_DBContext())
            {
                var effects = db.EffectCatalogs.ToList();
                checkedListBox1.DataSource = effects;
                checkedListBox1.DisplayMember = "effect";
                checkedListBox1.ValueMember = "id";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                if (!db.Citizens
                    .ToList()
                    .Where(c => c.Dui.Equals(txtboxDUI.Text))
                    .Any())
                {
                    MessageBox.Show("El DUI ingresado no corresponde a ningún DUI almacenado en la base de datos.", "ERROR!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Sujeto = db.Citizens.ToList().Where(c => c.Dui.Equals(txtboxDUI.Text)).First();
                    var idDate = db.Appointments.Where(a => a.IdAppointment1.Equals(Sujeto.IdAppointment1)).ToList();
                    Cita = idDate.First();
                    if (Cita.TimeDateVaccine2 != null)
                    {
                        MessageBox.Show("Ciudadano ya tuvo segunda cita", "ERROR!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Cita.TimeDateRow == null || Cita.TimeDateVaccine == null)
                        {


                            Cita = db.Appointments
                            .ToList()
                            .Where(c => c.IdAppointment1.Equals(Sujeto.IdAppointment1))
                            .First();

                            NombreCiudadano.Text = "Primera cita de " + Sujeto.Name + " es:";
                            citaFecha.Text = Cita.TimeDate.Value.Date.ToShortDateString();
                            citaHora.Text = Cita.TimeDate.Value.ToShortTimeString();
                            tabControl1.SelectedIndex = 1;
                        }
                        else
                        {
                            Cita = db.Appointments
                            .ToList()
                            .Where(c => c.IdAppointment1.Equals(Sujeto.IdAppointment1))
                            .First();

                            NombreCiudadano.Text = "Segunda cita de " + Sujeto.Name + " es:";
                            citaFecha.Text = Cita.TimeDat2.Value.ToShortDateString();
                            citaHora.Text = Cita.TimeDat2.Value.ToShortTimeString();
                            tabControl1.SelectedIndex = 1;
                        }
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                if (Cita.TimeDateRow == null || Cita.TimeDateVaccine == null)
                {
                    Cita.TimeDateRow = DateTime.Now;
                    filaHora.Text = Cita.TimeDateRow.ToString();
                    tabControl1.SelectedIndex = 2;
                }
                else
                {
                    Cita.TimeDateRow2 = DateTime.Now;
                    filaHora.Text = Cita.TimeDateRow2.ToString();
                    tabControl1.SelectedIndex = 2;
                }
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                if (Cita.TimeDateVaccine == null)
                {
                    Cita.TimeDateVaccine = DateTime.Now;
                    horaVacuna.Text = Cita.TimeDateVaccine.ToString();
                    tabControl1.SelectedIndex = 3;
                    timer1.Enabled = true;
                }
                else
                {
                    Cita.TimeDateVaccine2 = DateTime.Now;
                    horaVacuna.Text = Cita.TimeDateVaccine2.ToString();
                    tabControl1.SelectedIndex = 3;
                    timer1.Enabled = true;
                }
                
            }
            
        }

        private void saveExit_Click(object sender, EventArgs e)
        {
            if(MIN != 5)
            {
            var res = MessageBox.Show("¡Alerta! No han pasado 30 minutos desde que le han puesto la vacuna a " + Sujeto.Name + ". ¿Seguro que quieres salir?", "PRECAUCIÓN!!!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) { Close(); }
            } else { Close(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MIN == 2) 
            { 
                timer1.Enabled = false;

                if (Cita.TimeDateVaccine2 == null)
                {
                    MessageBox.Show("Cita Completada.", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    secondDate();
                }
            }
            else
            {
                if (SEG < 59) { SEG += 1; } else { MIN += 1; SEG = 0; }
                if (SEG < 10) { tiempoSEG.Text = "0" + SEG.ToString(); } else { tiempoSEG.Text = SEG.ToString(); }
                if (MIN < 10) { tiempoMIN.Text = "0" + MIN.ToString(); } else { tiempoMIN.Text = MIN.ToString(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var db = new FinalProjectPOO_DBContext();
            var detectdate = db.Appointments.Where(a => a.IdAppointment1.Equals(Cita.IdAppointment1)).ToList();
            if (detectdate.First().TimeDateRow == null || detectdate.First().TimeDateVaccine == null)
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    foreach (EffectCatalog item in checkedListBox1.CheckedItems)
                    {
                        EffectAppointment1 effect = new EffectAppointment1();
                        effect.IdAppointment1 = Cita.IdAppointment1;
                        effect.IdEffectCatalog = item.Id;
                        effect.Effectminute = MIN;
                        db.Add(effect);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Efecto(s) registrado", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    foreach (EffectCatalog item in checkedListBox1.CheckedItems)
                    {
                        EffectAppointment2 effect = new EffectAppointment2();
                        effect.IdAppointment2 = Cita.IdAppointment1;
                        effect.IdEffectCatalog = item.Id;
                        effect.Effectminute = MIN;
                        db.Add(effect);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Efecto(s) registrado", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       private void secondDate ()
        {
            var db = new FinalProjectPOO_DBContext();
            var rand = new Random();
            int n;
            n = rand.Next(42, 56);
            var date = DateTime.Now.Date;
            date = date.AddDays(n);
            n = rand.Next(5, 17);
            date = date.AddHours(n);
            Cita.TimeDat2 = date;
            n = rand.Next(1, db.Cabins.Count());
            Cita.IdCabinAppointment2 = n;
            var db2 = new FinalProjectPOO_DBContext();
            db2.Update(Cita);
            db2.SaveChanges();
            var cabin = db2.Cabins.Where(c => c.Id.Equals(Cita.IdCabinAppointment2));
            MessageBox.Show("Cita Completada, iniciando segunda cita.", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Fecha cita = {Cita.TimeDat2} Dirreccion = {cabin.First().Address}, ", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bttFinish_Click(object sender, EventArgs e)
        {
            if (Cita.TimeDateVaccine2 != null )
            {
                MessageBox.Show("Cita Completada.", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var db2 = new FinalProjectPOO_DBContext();
                db2.Update(Cita);
                db2.SaveChanges();
                this.Close();
            }
            else
            {
                secondDate();
            }
        }
    }
}
