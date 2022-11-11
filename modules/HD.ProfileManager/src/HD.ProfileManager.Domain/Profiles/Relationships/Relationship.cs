using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.Relationships
{
    public class Relationship : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Disabled { get; set; }
      
    }
}
