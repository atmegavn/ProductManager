using HD.ProfileManager.Employees;
using HD.ProfileManager.Locations;
using HD.ProfileManager.Profiles.BankAccounts;
using HD.ProfileManager.Profiles.Emails;
using HD.ProfileManager.Profiles.IDCards;
using HD.ProfileManager.Profiles.PhoneNumbers;
using HD.ProfileManager.Profiles.Relatives;
using HD.ProfileManager.Profiles.SocialContacts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace HD.ProfileManager.Profiles
{
    public class Profile: FullAuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset DateOfBird { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string TaxCode { get; set; }
        public Guid ProfileTypeId { get; set; }
        public ProfileType ProfileType { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<IDCard> Cards { get; set; }
        public virtual ICollection<Address> Address { get; private set; }
        public virtual ICollection<Relative> Relatives { get; set; }
        public virtual ICollection<SocialContact> SocialLinks { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
