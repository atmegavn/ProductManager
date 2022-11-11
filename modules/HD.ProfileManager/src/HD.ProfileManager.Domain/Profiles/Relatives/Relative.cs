using HD.ProfileManager.Employees;
using HD.ProfileManager.Profiles.Relationships;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Profiles.Relatives
{
    public class Relative : Entity<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ProfileId { get; set; }
        public Guid RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
        public Guid? PersonId { get; set; }
    }
}
