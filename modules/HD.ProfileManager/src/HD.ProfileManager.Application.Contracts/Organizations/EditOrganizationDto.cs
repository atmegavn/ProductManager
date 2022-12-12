using HD.ProfileManager.Employees;
using HD.ProfileManager.OrganizationPositions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Organizations
{
    public class EditOrganizationDto
    {
        [Required]
        [StringLength(EmployeeConsts.CodeMaxLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(EmployeeConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid ParentId { get; set; }
        public OrganizationLevel Level { get; set; }
        public List<OrganizationPositionDto> Positions { get; set; }
    }
}
