using System;
using System.Collections.Generic;

#nullable disable

namespace FinalPOOBD
{
    public partial class Citizen
    {
        public Citizen()
        {
            Diseases = new HashSet<Disease>();
        }

        public string Dui { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int? IdAppointment1 { get; set; }
        public int? IdInstitution { get; set; }

        public virtual Appointment IdAppointment1Navigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
