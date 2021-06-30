using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using FinalPOOBD.databaseContext;

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
            dgvAppointmentTracking.DataSource = null;
            dgvAppointmentTracking.DataSource = addDateInformation();
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            FinalProjectPOO_DBContext db = new FinalProjectPOO_DBContext();
            var listOcitizen = db.Citizens.ToList();
            var results = listOcitizen.Where(u => u.Dui.Equals(txtDui.Text)).ToList();

            if (results.Count == 0 || txtDui.Text.Length == 0)
            {
                MessageBox.Show("Ciudadano no encontrado", "Vacunacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new FinalProjectPOO_DBContext())
                {
                    dgvAppointmentTracking.DataSource = null;

                    var citizen = context.Citizens.First(a => a.Dui.Equals(txtDui.Text));
                    var newDS = context.Appointments.Where(e => e.IdAppointment1.Equals(citizen.IdAppointment1)).ToList();

                    var mappedDS = addDateInformation();
                    var appointmentSearch = mappedDS.Where(m => m.ID.Equals(newDS.First().IdAppointment1)).ToList();
                    dgvAppointmentTracking.DataSource = appointmentSearch;
                }
            }
        }

        private void bttnGeneratePDF_Click(object sender, EventArgs e)
        {
            var selected = dgvAppointmentTracking.SelectedRows[0].DataBoundItem as DateInformation;
            FinalProjectPOO_DBContext db = new FinalProjectPOO_DBContext();
            var listOcitizen = db.Citizens.ToList();
            var results = listOcitizen.Where(u => u.IdAppointment1.Equals(selected.ID)).ToList();
            if (results.Count > 0)
            {
                GeneratePDF(results.First().Dui);
            }
            else
            {
                MessageBox.Show("Ciudadano no encontrado", "Vacunacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<DateInformation> addDateInformation()
        {
            FinalProjectPOO_DBContext db = new FinalProjectPOO_DBContext();
            var data = db.Appointments.ToList();
            var datacabin = db.Cabins.ToList();
            List<DateInformation> list = new List<DateInformation>();
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    DateInformation datevalue = new DateInformation();
                    datevalue.ID = data[i].IdAppointment1;
                    datevalue.Fecha_hora_cita = data[i].TimeDate;
                    datevalue.Fecha_hora_cola = data[i].TimeDateRow;
                    datevalue.Fecha_hora_vacuna = data[i].TimeDateVaccine;
                    var addreCabin = datacabin.Where(d => d.Id.Equals(data[i].IdCabinAppointment1)).ToList();
                    datevalue.Dirrecion1 = addreCabin.First().Address;
                    datevalue.Fecha_hora_cita2 = data[i].TimeDat2;
                    datevalue.Fecha_hora_cola2 = data[i].TimeDateRow2;
                    datevalue.Fecha_hora_vacuna2 = data[i].TimeDateVaccine2;
                    var addreCabin2 = datacabin.Where(d => d.Id == data[i].IdCabinAppointment2).ToList();
                    if (addreCabin2.Count > 0)
                    {
                        datevalue.Dirrecion2 = addreCabin2.First().Address;
                    }
                    else
                    {
                        datevalue.Dirrecion2 = null;
                    }
                    list.Add(datevalue);
                }
                return list;
            }
            else
            {
                return list;
            }
        }
        private void GeneratePDF(string dui)
        {
            string MachineName = Environment.UserName;
            var db = new FinalProjectPOO_DBContext();
            var data = db.Citizens.Where(c => c.Dui.Equals(dui));
            var fs = new FileStream($@"C:\Users\{MachineName}\Documents\PDFFormulario{dui}.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
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
            doc.Add(new Phrase($"Fecha y hora = {dataappo.First().TimeDate.ToString()}", StandarFont));
            doc.Add(Chunk.NEWLINE);
            if (dataappo.First().TimeDateRow == null)
            {
                doc.Add(new Phrase($"Fecha y hora fila = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Fecha y hora fila  = {dataappo.First().TimeDateRow.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            if (dataappo.First().TimeDateVaccine == null)
            {
                doc.Add(new Phrase($"Fecha y hora vacuna  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Fecha y hora vacuna  = {dataappo.First().TimeDateVaccine.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            if (dataappo.First().IdCabinAppointment1 == null)
            {
                doc.Add(new Phrase($"Dirrecion  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Dirrecion  = {datacabin1.First().Address}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Informacion del Segunda cita", StandarFont));
            doc.Add(Chunk.NEWLINE);
            if (dataappo.First().TimeDat2 == null)
            {
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Phrase($"Fecha y hora  = {dataappo.First().TimeDat2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            if (dataappo.First().TimeDateRow2 == null)
            {
                doc.Add(new Phrase($"Fecha y hora fila  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Fecha y hora fila  = {dataappo.First().TimeDateRow2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            if (dataappo.First().TimeDateVaccine2 == null)
            {
                doc.Add(new Phrase($"Fecha y hora vacuna  = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
                doc.Add(new Phrase($"Fecha y hora vacuna  = {dataappo.First().TimeDateVaccine2.Value}", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            if (dataappo.First().IdCabinAppointment2 == null)
            {
                doc.Add(new Phrase($"Dirrecion = null", StandarFont));
                doc.Add(Chunk.NEWLINE);
            }
            else
            {
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
            effect1.BorderWidth = 0;
            effect1.BorderWidthBottom = 0.75f;
            PdfPCell effect2 = new PdfPCell(new Phrase("Efectos de vacula cita dos", StandarFont));
            effect2.BorderWidth = 0;
            effect2.BorderWidthBottom = 0.75f;
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
            var db2 = new FinalProjectPOO_DBContext();
            var effect1list = db2.EffectAppointment1s.Where(e => e.IdAppointment1.Equals(dataappo.First().IdAppointment1));
            var effect = db2.EffectCatalogs.ToList();
            if (effect1list.Count() > 0)
            {
                foreach (EffectAppointment1 item in effect1list)
                {
                    var dataeffect = effect.Where(e => e.Id == item.IdEffectCatalog).ToList();
                    effect1 = new PdfPCell(new Phrase(dataeffect.First().Effect, StandarFont));
                    effect1.BorderWidth = 0;

                    tbl1.AddCell(effect1);
                }
            }
            var effect1list2 = db2.EffectAppointment2s.Where(e => e.IdAppointment2.Equals(dataappo.First().IdAppointment1));
            if (effect1list2.Count() > 0)
            {
                
                foreach (EffectAppointment2 item in effect1list2)
                {
                   var dataeffect = effect.Where(e => e.Id == item.IdEffectCatalog).ToList();
                    effect2 = new PdfPCell(new Phrase(dataeffect.First().Effect, StandarFont));
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
            MessageBox.Show("Documento pdf Creado, se agrego en el archivo documentos", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            txtDui.Clear();
            dgvAppointmentTracking.DataSource = null;
            dgvAppointmentTracking.DataSource = addDateInformation();
            tabControl1.SelectedIndex = 0;
        }

        private void dgvAppointmentTracking_DoubleClick(object sender, EventArgs e)
        {
            var selected = dgvAppointmentTracking.SelectedRows[0].DataBoundItem as DateInformation;
            FinalProjectPOO_DBContext db = new FinalProjectPOO_DBContext();
            var listOcitizen = db.Citizens.ToList();
            var results = listOcitizen.Where(u => u.IdAppointment1.Equals(selected.ID)).ToList();
            lblinfocitizen.Text = $"Ciudadano Seleccionado: {results[0].Dui} {results[0].Name}";
        }
    }
}
