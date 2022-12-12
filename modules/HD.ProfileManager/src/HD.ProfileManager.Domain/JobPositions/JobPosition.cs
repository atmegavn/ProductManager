using HD.ProfileManager.OrganizationPositions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.JobPositions
{
    public class JobPosition: Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirement { get; set; }
        public Guid JobFamilyId { get; set; }
        public JobFamily JobFamily { get; set; }
        public int PositionClass { get; set; }
        public JobLevel Level { get; set; } 
        public bool? Disabled { get; set; }

    }
}
