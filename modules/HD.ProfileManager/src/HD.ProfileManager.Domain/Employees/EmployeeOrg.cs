using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.Employees
{
    public class EmployeeOrg : Entity
    {
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid JobPositionId { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid ContractId { get; set; }
        public Guid DecisionId { get; set; }
        public Boolean IsPrimary { get; set; }


        public override object[] GetKeys()
        {
            return new object[] { EmployeeId, OrganizationId };
        }
    }
}
