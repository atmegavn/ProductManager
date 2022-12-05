using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Profiles.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Organizations
{
    public class Organization: FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; } // mã dơn vị
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ParentId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public OrganizationLevel Level { get; set; }
        public bool? Disabled { get; set; }

        public virtual ICollection<OrganizationPosition> Positions { get; set; }
    }
}
