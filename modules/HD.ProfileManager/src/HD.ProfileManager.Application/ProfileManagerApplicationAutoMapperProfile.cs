using AutoMapper;
using HD.ProfileManager.Employees;
using HD.ProfileManager.Organizations;
using System.Collections.Generic;
namespace HD.ProfileManager;

public class ProfileManagerApplicationAutoMapperProfile : Profile
{
    public ProfileManagerApplicationAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Organization, OrganizationDto>();
        CreateMap<Organization, OrganizationLookupDto>();
    }
}
