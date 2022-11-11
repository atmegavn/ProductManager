using HD.ProfileManager.Locations.Nationals;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Locations.Provincials
{
    public class Provincial : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid NationalId { get; set; }
        public National National { get; set; }
    }
}
