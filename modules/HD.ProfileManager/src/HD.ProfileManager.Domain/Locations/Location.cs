using HD.ProfileManager.Locations.Districts;
using HD.ProfileManager.Locations.Nationals;
using HD.ProfileManager.Profiles;
using HD.ProfileManager.Locations.Provincials;
using HD.ProfileManager.Locations.Streets;
using HD.ProfileManager.Locations.Villages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.Locations
{
    public class Location : Entity<Guid>
    {
        public string Address { get; set; }
        public Guid StreetId { get; set; }
        public Street Street { get; set; }
        public Guid VillageId { get; set; }
        public Village Village { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
        public Guid ProvincialId { get; set; }
        public Provincial Provincial { get; set; }
        public Guid NationalId { get; set; }
        public National National { get; set; }
        public Guid ProfileId { get; set; }
    }
}
