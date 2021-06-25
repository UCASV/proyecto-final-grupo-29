using System;
using System.Collections.Generic;

#nullable disable

namespace Procedo_de_cita.databaseContext
{
    public partial class EffectAppointment2
    {
        public int Id { get; set; }
        public int? IdAppointment2 { get; set; }
        public int? IdEffectCatalog { get; set; }

        public virtual Appointment IdAppointment2Navigation { get; set; }
        public virtual EffectCatalog IdEffectCatalogNavigation { get; set; }
    }
}
