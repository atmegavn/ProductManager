using HD.ProfileManager.Locations.Provincials;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Locations.Districts
{
    public class District : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProvincialId { get; set; }
        public Provincial Provincial { get; set; }
    }
}
