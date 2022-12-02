using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HD.ProfileManager.Organizations
{
    public class OrganizationDto: AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }    
        public string Location { get; set; }    
        public Guid ParentId { get; set; }
        public OrganizationLevel Level { get; set; }
    }
}
