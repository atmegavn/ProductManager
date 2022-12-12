using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.ProfileManager.Organizations
{
    public class DeleteOrganizaionDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BackUrl { get; set; }
    }
}
