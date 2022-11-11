using HD.ProfileManager.Organizations;
using HD.ProfileManager.Profiles;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Employees
{
    public class Employee: FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfOnboard { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public Guid PositionId { get; set; }
        public Guid OrganzinationId { get; set; }
    }
}
