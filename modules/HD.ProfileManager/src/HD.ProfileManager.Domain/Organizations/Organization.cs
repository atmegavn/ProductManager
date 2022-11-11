using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Organizations
{
    public class Organization: FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public Organization Parent { get; set; }
        public string Location { get; set; }
        public OrganizationLevel Level { get; set; }
        public bool Disabled { get; set; }
    }
}
