using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Organizations
{
    public interface IOrganizationRepository: IRepository<Organization,Guid>
    {
    }
}
