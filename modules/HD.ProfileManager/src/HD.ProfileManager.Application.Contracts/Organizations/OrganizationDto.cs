using HD.ProfileManager.OrganizationPositions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Organizations
{
    public class OrganizationDto: FullAuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }    
        public string Location { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }    
        public string Phone { get; set; }    
        public string Email { get; set; }
        public bool? Disabled { get; set; }
        public Guid ParentId { get; set; }
        public OrganizationLevel Level { get; set; }
        public List<OrganizationPositionDto> Positions { get; set; }
    }
}
