using System;
using System.Collections.Generic;
using System.Text;

namespace HD.ProfileManager.Employees
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public DateTimeOffset DateOfOnboard { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid PositionId { get; set; }
        public Guid OrganzinationId { get; set; }
    }
}
