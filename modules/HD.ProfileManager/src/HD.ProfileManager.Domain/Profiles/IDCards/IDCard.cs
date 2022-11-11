using HD.ProfileManager.Employees;
using HD.ProfileManager.Locations;
using HD.ProfileManager.Locations.Nationals;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.IDCards
{
    public class IDCard : Entity<Guid>
    {
        public IDCardType Type { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset DateOfBith { get; set; }
        public DateTimeOffset DateOfExpiry { get; set; }
        public National Nationality { get; set; }
        public Location PlaceOfOrigin { get; set; }
        public Location PlaceOfResidence { get; set; }
        public string PersonalIdentification { get; set; }
        public DateTimeOffset DateOfProvided { get; set; }
        public Guid ProfileId { get; set; }
    }
}
