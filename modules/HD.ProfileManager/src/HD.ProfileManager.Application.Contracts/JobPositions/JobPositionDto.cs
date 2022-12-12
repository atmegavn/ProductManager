using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.JobPositions
{
    public class JobPositionDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Requirement { get; set; }
        public JobLevel Level { get; set; }
        public JobFamilyDto JobFamily { get; set; }

    }
}
