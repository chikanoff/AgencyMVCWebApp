using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class Case
    {
        public Case()
        {
            ConfirmationDocuments = new HashSet<ConfirmationDocument>();
        }

        public int Id { get; set; }
        public int AgentId { get; set; }
        public int PolicyId { get; set; }
        public DateTime Date { get; set; }
        public double Payment { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<ConfirmationDocument> ConfirmationDocuments { get; set; }
    }
}
