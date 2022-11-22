using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Employees
{
    public class EmployeeDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTimeOffset DateOfOnboard { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid ProfileId { get; set; }
        public Guid PositionId { get; set; }
        public Guid OrganzinationId { get; set; }
    }
}
