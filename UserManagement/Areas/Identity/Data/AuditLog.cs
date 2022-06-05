using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Areas.Identity.Data
{
    public class AuditLog
    {
        public long Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
