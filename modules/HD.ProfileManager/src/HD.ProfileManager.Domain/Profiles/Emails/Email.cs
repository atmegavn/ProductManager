using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.Emails
{
    public class Email : Entity<Guid>
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid ProfileId { get; set; }
        public bool IsPrimary { get; set; }

    }
}
