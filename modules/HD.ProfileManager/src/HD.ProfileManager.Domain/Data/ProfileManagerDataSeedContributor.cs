using HD.ProfileManager.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace HD.ProfileManager.Data
{
    public class ProfileManagerDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Employee,Guid> _employeeRepository;

        public ProfileManagerDataSeedContributor(IRepository<Employee, Guid> employeeRepository) {
            _employeeRepository = employeeRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _employeeRepository.GetCountAsync() > 0)
            {
                return;
            }

            var employee1 = new Employee()
            {
                Name = "Thành",
                DateOfOnboard = new DateTimeOffset(),
                IsDeleted = false,

            };

            await _employeeRepository.InsertAsync(employee1);
        }
    }
}
