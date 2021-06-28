﻿using System;
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

namespace Seguimiento_de_citas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void search_Click(object sender, EventArgs e)
        {
            FinalProjectPOO_DBContext db = new FinalProjectPOO_DBContext();
            var listOcitizen = db.Citizens.Include(c => c.Id).ToList();
            var results = listdui.Where(u => u.Dui.Equals(txtDui.Text)).ToList();

            if (results.Count == 0 || txtDui.Text.Length == 0)
            {
                MessageBox.Show("Ciudadano no encontrado", "Vacunacion", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                using (var context = new AppointmentContext())
                {
                    dgvAppointmentTracking.DataSource = null;

                    var citizen = context.Citizens.First(a => a.Dui.Equals(txtDui.Text));
                    var newDS = context.IdAppointment.Where(e => e.Id.Equals(citizen.id_appointment1)).ToList();

                    var mappedDS = new List<IdAppointmentI>();
                    newDS.ForEach(i => mappedDS.Add(FinalProjectPOO_DBMapped.Mapid_appointment1ToIdAppointment(e)));
                    dgvAppointmentTracking.DataSource = mappedDS;
                }
            }
        }
    }

        private void generate_Click(object sender, EventArgs e)
        {
        GeneratePDF();
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
            MessageBox.Show("Documento pdf Creado, se agrego en el archivo documentos", "Vacunacion UCA", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDui_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
