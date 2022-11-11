using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.Banks
{
    public class Bank : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
    }
}
