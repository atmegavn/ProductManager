using HD.ProfileManager.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles
{
    public class Address: Entity
    {
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Guid ProfileId { get; set; }
        public Boolean IsMain { get; set; }
        public Location Location { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { LocationId, ProfileId };
        }
    }
}
