using System;
using System.Collections.Generic;

#nullable disable

namespace Procedo_de_cita.databaseContext
{
    public partial class Disease
    {
        public int Id { get; set; }
        public string DuiCitizen { get; set; }
        public string Disease1 { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
    }
}
