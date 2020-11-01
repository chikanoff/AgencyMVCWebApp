using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class ToiPolicy
    {
        public int Id { get; set; }
        public int ToiId { get; set; }
        public int PolicyId { get; set; }

        public virtual Policy Policy { get; set; }
        public virtual TypeOfinsurance Toi { get; set; }
    }
}
