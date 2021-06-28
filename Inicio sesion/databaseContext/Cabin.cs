using System;
using System.Collections.Generic;

#nullable disable

namespace Inicio_sesion.databaseContext
{
    public partial class Cabin
    {
        public Cabin()
        {
            AppointmentIdCabinAppointment1Navigations = new HashSet<Appointment>();
            AppointmentIdCabinAppointment2Navigations = new HashSet<Appointment>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public int? IdEmployeeCharge { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual Employee IdEmployeeChargeNavigation { get; set; }
        public virtual ICollection<Appointment> AppointmentIdCabinAppointment1Navigations { get; set; }
        public virtual ICollection<Appointment> AppointmentIdCabinAppointment2Navigations { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
