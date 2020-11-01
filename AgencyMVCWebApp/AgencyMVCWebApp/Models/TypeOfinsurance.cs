using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class TypeOfinsurance
    {
        public TypeOfinsurance()
        {
            ToiPolicies = new HashSet<ToiPolicy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Payment { get; set; }

        public virtual ICollection<ToiPolicy> ToiPolicies { get; set; }
    }
}
