using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Cases = new HashSet<Case>();
            ToiPolicies = new HashSet<ToiPolicy>();
        }

        public int Id { get; set; }
        public int AgentId { get; set; }
        public int ClientId { get; set; }
        public DateTime RegistredAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<ToiPolicy> ToiPolicies { get; set; }
    }
}
