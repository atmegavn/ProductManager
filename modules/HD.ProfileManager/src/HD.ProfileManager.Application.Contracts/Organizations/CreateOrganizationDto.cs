using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Organizations
{
    public class CreateOrganizationDto: FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(EmployeeConsts.CodeMaxLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(EmployeeConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public OrganizationLevel Level { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid? ParentId { get; set; }
    }
}
