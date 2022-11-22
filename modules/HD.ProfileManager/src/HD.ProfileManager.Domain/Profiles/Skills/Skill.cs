using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.Profiles.Skills
{
    public class Skill: Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
    }
}
