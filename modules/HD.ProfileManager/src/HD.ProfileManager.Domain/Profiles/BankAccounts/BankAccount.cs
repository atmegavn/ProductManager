using HD.ProfileManager.Profiles.Banks;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace HD.ProfileManager.Profiles.BankAccounts
{
    public class BankAccount : Entity<Guid>
    {
        public string AccountNumber { get; set; }
        public string Descriptioin { get; set; }
        public Guid BankId { get; set; }
        public Guid ProfileId { get; set; }
        public bool IsPrimary { get; set; }
    }
}
