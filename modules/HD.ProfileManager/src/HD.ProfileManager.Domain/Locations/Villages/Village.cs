using HD.ProfileManager.Locations.Districts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Locations.Villages
{
    public class Village : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
