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

                    Cita = db.Appointments
                    .ToList()
                    .Where(c => c.IdAppointment1.Equals(Sujeto.IdAppointment1))
                    .First();

                    NombreCiudadano.Text = "La cita de " + Sujeto.Name + " es:";
                    citaFecha.Text = Cita.TimeDate.ToShortDateString();
                    citaHora.Text = Cita.TimeDate.ToShortTimeString();
                    tabControl1.SelectedIndex = 1;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                Cita.TimeDateRow = DateTime.Now;
                filaHora.Text = Cita.TimeDateRow.ToString();
                tabControl1.SelectedIndex = 2;
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new FinalProjectPOO_DBContext())
            {
                Cita.TimeDateVaccine = DateTime.Now;
                horaVacuna.Text = Cita.TimeDateVaccine.ToString();
                tabControl1.SelectedIndex = 3;
                timer1.Enabled = true;
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
            if (MIN == 2) { timer1.Enabled = false; }
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

        }
    }
}
