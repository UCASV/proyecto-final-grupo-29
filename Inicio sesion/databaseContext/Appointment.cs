using System;
using System.Collections.Generic;

#nullable disable

namespace Inicio_sesion.databaseContext
{
    public partial class Appointment
    {
        public Appointment()
        {
            Citizens = new HashSet<Citizen>();
            EffectAppointment1s = new HashSet<EffectAppointment1>();
            EffectAppointment2s = new HashSet<EffectAppointment2>();
        }

        public int IdAppointment1 { get; set; }
        public DateTime? TimeDate { get; set; }
        public DateTime? TimeDateRow { get; set; }
        public DateTime? TimeDateVaccine { get; set; }
        public int? IdCabinAppointment1 { get; set; }
        public int? IdAppointment2 { get; set; }
        public DateTime? TimeDat2 { get; set; }
        public DateTime? TimeDateRow2 { get; set; }
        public DateTime? TimeDateVaccine2 { get; set; }
        public int? IdCabinAppointment2 { get; set; }

        public virtual Cabin IdCabinAppointment1Navigation { get; set; }
        public virtual Cabin IdCabinAppointment2Navigation { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
        public virtual ICollection<EffectAppointment1> EffectAppointment1s { get; set; }
        public virtual ICollection<EffectAppointment2> EffectAppointment2s { get; set; }
    }
}
