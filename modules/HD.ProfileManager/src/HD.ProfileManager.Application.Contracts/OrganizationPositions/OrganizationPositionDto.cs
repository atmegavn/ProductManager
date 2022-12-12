using HD.ProfileManager.JobPositions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.OrganizationPositions
{
    public class OrganizationPositionDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid JobPositionId { get; set; }

        public JobPositionDto Position { get; set; }
    }
}
