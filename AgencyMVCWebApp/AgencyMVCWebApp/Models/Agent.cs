using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Cases = new HashSet<Case>();
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsWorker { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public double Commision { get; set; }
        public string Contract { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
