using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.ProfileManager.Organizations
{
    public class CreateOrganizationDto
    {
        [Required]
        [StringLength(EmployeeConsts.CodeMaxLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(EmployeeConsts.NameMaxLength)]
        public string Name { get; set; }

        public string Location { get; set; }

        [Required]
        public OrganizationLevel Level { get; set; }

        public Guid? ParentId { get; set; }

        public string BackUrl { get; set; }
    }
}
