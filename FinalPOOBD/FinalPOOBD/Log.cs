using System;
using System.Collections.Generic;

#nullable disable

namespace FinalPOOBD
{
    public partial class Log
    {
        public int Id { get; set; }
        public int? IdCabin { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? TimeDate { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
