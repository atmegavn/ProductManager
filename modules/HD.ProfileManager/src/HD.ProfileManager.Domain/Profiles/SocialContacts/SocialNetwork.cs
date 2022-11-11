using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.Profiles.SocialContacts
{
    public class SocialNetwork: Entity<Guid>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Boolean Disabled { get; set; }
    }
}
