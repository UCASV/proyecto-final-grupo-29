using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento_de_citas
{
    class DateInformation
    {
        public int IdAppointment1 { get; set; }
        public DateTime? Fecha_hora_cita { get; set; }
        public DateTime? Fecha_hora_cola { get; set; }
        public DateTime? Fecha_hora_vacuna { get; set; }
        public string? Dirrecion1 { get; set; }
        public int? IdAppointment2 { get; set; }
        public DateTime? Fecha_hora_cita2 { get; set; }
        public DateTime? Fecha_hora_cola2 { get; set; }
        public DateTime? Fecha_hora_vacuna2 { get; set; }
        public string? Dirrecion2 { get; set; }
    }
}
