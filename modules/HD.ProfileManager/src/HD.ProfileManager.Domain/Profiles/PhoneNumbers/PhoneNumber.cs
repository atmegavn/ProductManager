using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.PhoneNumbers
{
    public class PhoneNumber : Entity<Guid>
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
        public Guid ProfileId { get; set; }

    }
}
