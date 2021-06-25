using System;
using System.Collections.Generic;

#nullable disable

namespace Procedo_de_cita.databaseContext
{
    public partial class EffectAppointment1
    {
        public int Id { get; set; }
        public int? IdAppointment1 { get; set; }
        public int? IdEffectCatalog { get; set; }

        public virtual Appointment IdAppointment1Navigation { get; set; }
        public virtual EffectCatalog IdEffectCatalogNavigation { get; set; }
    }
}
