using System;
using System.Collections.Generic;

#nullable disable

namespace FinalPOOBD.databaseContext
{
    public partial class Employee
    {
        public Employee()
        {
            Cabins = new HashSet<Cabin>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? IdTypeEmployee { get; set; }

        public virtual TypeEmployee IdTypeEmployeeNavigation { get; set; }
        public virtual ICollection<Cabin> Cabins { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
