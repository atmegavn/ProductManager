using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.ProfileManager.Employees
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(EmployeeConsts.CodeMaxLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(EmployeeConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public DateTimeOffset DateOfOnboard { get; set; }
        [Required]
        [StringLength(EmployeeConsts.EmailMaxLength)]
        public string Email { get; set; }
        [Required]
        [StringLength(EmployeeConsts.MobileMaxLength)]
        public string Mobile { get; set; }
       
    }
}
