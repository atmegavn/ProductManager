using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.SocialContacts
{
    public class SocialContact: Entity<Guid>
    {
        public string Url { get; set; }
        public string Desciption { get; set; }
        public Guid SocialNetworkId { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public Guid ProfileId { get; set; }
        public Boolean IsPrimary { get; set; }
    }
}
