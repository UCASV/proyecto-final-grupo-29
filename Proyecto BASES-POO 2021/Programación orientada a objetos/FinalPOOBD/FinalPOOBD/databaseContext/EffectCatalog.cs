using System;
using System.Collections.Generic;

#nullable disable

namespace FinalPOOBD.databaseContext
{
    public partial class EffectCatalog
    {
        public EffectCatalog()
        {
            EffectAppointment1s = new HashSet<EffectAppointment1>();
            EffectAppointment2s = new HashSet<EffectAppointment2>();
        }

        public int Id { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<EffectAppointment1> EffectAppointment1s { get; set; }
        public virtual ICollection<EffectAppointment2> EffectAppointment2s { get; set; }
    }
}
