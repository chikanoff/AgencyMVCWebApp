using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class Client
    {
        public Client()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string SerialNumber { get; set; }
        public string Residence { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
