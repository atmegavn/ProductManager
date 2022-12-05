using AutoMapper;
using HD.ProfileManager.Employees;
using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Organizations;
using System.Collections.Generic;
namespace HD.ProfileManager;

public class ProfileManagerApplicationAutoMapperProfile : Profile
{
    public ProfileManagerApplicationAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Organization, CreateOrganizationDto>();
        CreateMap<Organization, OrganizationDto>();
        CreateMap<Organization, OrganizationLookupDto>();
        CreateMap<OrganizationPosition, OrganizationPositionDto>();
    }
}
