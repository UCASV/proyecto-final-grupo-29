using System;
using System.Collections.Generic;

#nullable disable

namespace Seguimiento_de_citas.databaseContext
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
