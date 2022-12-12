using System;
using System.Collections.Generic;
using System.Text;

namespace HD.ProfileManager.JobPositions
{
    public class JobFamilyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<JobPositionDto> Positions { get; set; }
    }
}
