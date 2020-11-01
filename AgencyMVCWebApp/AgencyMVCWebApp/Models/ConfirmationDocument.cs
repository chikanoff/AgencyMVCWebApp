using System;
using System.Collections.Generic;

namespace AgencyMVCWebApp.Models
{
    public partial class ConfirmationDocument
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }

        public virtual Case Case { get; set; }
    }
}
