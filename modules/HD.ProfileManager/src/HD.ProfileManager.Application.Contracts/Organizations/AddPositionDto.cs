using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.ProfileManager.Organizations
{
    public class AddPositionDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }
        public Guid JobPositionId { get; set; }
        public string BackUrl { get; set; }
    }
}
