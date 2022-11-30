using HD.ProfileManager.Employees;
using HD.ProfileManager.OrganizationPositions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace HD.ProfileManager.Decisions
{
    public class Decision : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string Number { get; set; }
        public Guid TypeId { get; set; }
        public DecisionType DecisionType { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid? DecisionMakerId { get; set; }
        public Employee DecisionMaker { get; set; }
        public Guid? DecisionReceiverId { get; set; }
        public Employee DecisionReceiver { get; set; }
        public DateTime? SignDate { get; set; }
        public DateTimeOffset? ApplyDate { get; set; }
        public DateTimeOffset? ExperiedDate { get; set; }

    }
}
