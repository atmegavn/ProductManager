﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Employees
{
    public interface IEmployeeRepostory : IRepository<Employee, Guid>
    {
    }
}
