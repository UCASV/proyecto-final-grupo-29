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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
                        DialogResult  r = MessageBox.Show("¿El ciudadano es una mayor de 18 años con enfermedades no transmisibles o alguna discapacidad?", "c", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if ((DateTime.Now.Year - dtpBirthDay.Value.Year) >= 60 || dbinstitution.Id == 2 || dbinstitution.Id == 3 || dbinstitution.Id == 4 || 
                            dbinstitution.Id == 5 || dbinstitution.Id == 7 || dbinstitution.Id == 8 || dbinstitution.Id == 9 || r == DialogResult.Yes)
                        {

                            var citizen = new Citizen();
                            //agregacion de datos del ciudadano
                            citizen.Dui = txtbDUI.Text;
                            citizen.Name = txtbName.Text;
                            citizen.Address = txtbAddress.Text;
                            citizen.Phone = Convert.ToInt32(txtbPhone.Text);
                            citizen.Email = txtbEmail.Text;
                            citizen.Birthday = dtpBirthDay.Value.Date;
                            citizen.IdAppointment1 = null;
                            citizen.IdInstitution = dbinstitution.Id;
                            //creacion de la cita
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
                            //añadiendo el id de la cita al ciudadano y guardandolo el la base de datos
                            int idAppointment = db.Appointments.OrderBy(c => c.IdAppointment1).Last().IdAppointment1;
                            citizen.IdAppointment1 = idAppointment;
                            db.Add(citizen);
                            db.SaveChanges();
                            // agregacion de la lista de enfermedades del ciudadano
                            if (ltbDisease.Items.Count == 0) { }
                            else
                            {
                                foreach (var item in ltbDisease.Items)
                                {
                                    var disease = new Disease();
                                    disease.DuiCitizen = citizen.Dui;
                                    disease.Disease1 = item.ToString();
                                    db.Add(disease);
                                    db.SaveChanges();
                                }
                            }
                            var cabin = db.Cabins.Where(c => c.Id.Equals(appointment.IdCabinAppointment1));
                            MessageBox.Show("Ciudadano Ingresado.", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show($"Fecha cita = {appointment.TimeDate} Dirreccion = {cabin.First().Address}, ", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returntonormal();
                            GeneratePDF(citizen.Dui);
                        }
                        else
                        {
                            MessageBox.Show("Usted no cumple con ninguna condición de un grupo de atención de prioridad.Por favor, espere a que este proceso sea habilitado para usted", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returntonormal();
                        }

                    }
                    else
                    {
                        MessageBox.Show("ERROR Dui duplicado!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR Digite mas de 5 caracteres en la barras de texto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ltbDisease.Items.Add(txtbDisease.Text);
                txtbDisease.Clear();
            }
            else
            {
                MessageBox.Show("ERROR Digite mas de 5 caracteres en la barra de texto de enfermedades", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttErase_Click(object sender, EventArgs e)
        {
            if (ltbDisease.Items.Count == 0)
            {
                MessageBox.Show("La lista no posee ningun dato", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ltbDisease.Items.Clear();
                MessageBox.Show("La lista se elimino correctamente", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void bttnform_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            returntonormal();
        }
        private void returntonormal()
        {
            tabControl1.SelectedIndex = 0;
            txtbDUI.Clear();
            txtbName.Clear();
            txtbAddress.Clear();
            txtbPhone.Clear();
            txtbEmail.Clear();
            txtbDisease.Clear();
            ltbDisease.Items.Clear();
            dtpBirthDay.Value = DateTime.Now;
            cmbIntitution.SelectedIndex = 0;
        }

        private void bttnGeneratePDF_Click(object sender, EventArgs e)
        {
            
            GeneratePDF("062843668");
        }
        private void GeneratePDF(string dui)
        {
            
            var db = new FinalProjectPOO_DBContext();
            var data = db.Citizens.Where(c => c.Dui.Equals(dui));
            var fs = new FileStream($@"C:\Users\HP\Documents\PDFFormulario{dui}.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER,5,5,7,7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            var datainst = db.Institutions.Where(inst => inst.Id.Equals(data.First().IdInstitution));
            var dataappo = db.Appointments.Where(appo => appo.IdAppointment1.Equals(data.First().IdAppointment1));
            var datacabin1 = db.Cabins.Where(cabin => cabin.Id.Equals(dataappo.First().IdCabinAppointment1));
            var datacabin2 = db.Cabins.Where(cabin => cabin.Id.Equals(dataappo.First().IdCabinAppointment2));
            doc.Open();
            doc.AddAuthor("Vacunacion UCA");
            doc.AddTitle("Formulario Ciudadano");
            iTextSharp.text.Font StandarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Add(new Paragraph("Formulario del Ciudadano"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Informacion del Ciudadano", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Dui del Ciudadano = {data.First().Dui}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Nombre del Ciudadano = {data.First().Name}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Dirrecion del Ciudadano = {data.First().Address}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Telefono del Ciudadano = {data.First().Phone}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Email del Ciudadano = {data.First().Email}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Fecha de nacimiento del Ciudadano = {data.First().Birthday.Value.Date}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Institucion del Ciudadano = {datainst.First().Institution1}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Informacion del Primera cita", StandarFont));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase($"Fecha y hora = {dataappo.First().TimeDate.Value}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            if (dataappo.First().TimeDateRow == null)
            {
                doc.Add(new Phrase($"Fecha y hora fila = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora vacuna  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Dirrecion  = {datacabin1.First().Address}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase("Informacion del Segunda cita", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora fila  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora vacuna  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Dirrecion = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Fecha y hora fila  = {dataappo.First().TimeDateRow.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora vacuna  = {dataappo.First().TimeDateVaccine.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Dirrecion  = {datacabin1.First().Address}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase("Informacion del Segunda cita", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora  = {dataappo.First().TimeDat2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora fila  = {dataappo.First().TimeDateRow2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora vacuna  = {dataappo.First().TimeDateVaccine2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Dirrecion  = {datacabin2.First().Address}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            PdfPTable tbl = new PdfPTable(1);
            PdfPTable tbl1 = new PdfPTable(1);
            PdfPTable tbl2 = new PdfPTable(1);
            tbl.WidthPercentage = 100;
            tbl1.WidthPercentage = 100;
            tbl2.WidthPercentage = 100;
            PdfPCell disease = new PdfPCell(new Phrase("Enfermedades", StandarFont));
            disease.BorderWidth = 0;
            disease.BorderWidthBottom = 0.75f;
            PdfPCell effect1 = new PdfPCell(new Phrase("Efectos de vacula cita uno", StandarFont));
            disease.BorderWidth = 0;
            disease.BorderWidthBottom = 0.75f;
            PdfPCell effect2 = new PdfPCell(new Phrase("Efectos de vacula cita dos", StandarFont));
            disease.BorderWidth = 0;
            disease.BorderWidthBottom = 0.75f;
            tbl.AddCell(disease);
            tbl1.AddCell(effect1);
            tbl2.AddCell(effect2);

            var diseaselist = db.Diseases.Where(d => d.DuiCitizen.Equals(dui));
            if (diseaselist.Count() > 0)
            {
                foreach (var item in diseaselist)
                {
                    disease = new PdfPCell(new Phrase(item.Disease1, StandarFont));
                    disease.BorderWidth = 0;

                    tbl.AddCell(disease);
                }
            }
            var effect1list = db.EffectAppointment1s.Where(e => e.IdAppointment1.Equals(dataappo.First().IdAppointment1));
            if (effect1list.Count() > 0)
            {
                foreach (var item in effect1list)
                {
                    var effect = db.EffectCatalogs.Where(e => e.Id.Equals(item.IdEffectCatalog));
                    effect1 = new PdfPCell(new Phrase(effect.First().Effect, StandarFont));
                    effect1.BorderWidth = 0;

                    tbl1.AddCell(effect1);
                }
            }
            var effect1list2 = db.EffectAppointment2s.Where(e => e.IdAppointment2.Equals(dataappo.First().IdAppointment1));
            if (effect1list2.Count() > 0)
            {
                foreach (var item in effect1list2)
                {
                    var effect = db.EffectCatalogs.Where(e => e.Id.Equals(item.IdEffectCatalog));
                    effect2 = new PdfPCell(new Phrase(effect.First().Effect, StandarFont));
                    effect2.BorderWidth = 0;

                    tbl2.AddCell(effect2);
                }
            }
            doc.Add(tbl);
            doc.Add(Chunk.NEWLINE);
            doc.Add(tbl1);
            doc.Add(Chunk.NEWLINE);
            doc.Add(tbl2);
            doc.Add(Chunk.NEWLINE);
            doc.Close();
            pw.Close();
            MessageBox.Show("Documento pdf Creado.", "c", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void detectnull( )
        {

        }
    }
}
