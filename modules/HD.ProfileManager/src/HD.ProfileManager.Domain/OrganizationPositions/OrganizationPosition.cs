using HD.ProfileManager.Decisions;
using HD.ProfileManager.Employees;
using HD.ProfileManager.JobPositions;
using HD.ProfileManager.Organizations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.OrganizationPositions
{
    public class OrganizationPosition: Entity<Guid>
    {
        public string Name { get; set; }
        public Guid? DecisionId { get; set; }
        public Decision Decision { get; set; }
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Guid JobPositionId { get; set; }
        public JobPosition Position { get; set; }
        
    }
}
