using System;
using System.Collections.Generic;

#nullable disable

namespace FinalPOOBD.databaseContext
{
    public partial class TypeEmployee
    {
        public TypeEmployee()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
