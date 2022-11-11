using HD.ProfileManager.Locations.Villages;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Locations.Streets
{
    public class Street : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid VillageId { get; set; }
        public Village Village { get; set; }

    }
}
