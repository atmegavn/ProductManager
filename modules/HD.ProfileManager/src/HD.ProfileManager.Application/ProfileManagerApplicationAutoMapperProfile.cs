using AutoMapper;
using HD.ProfileManager.Employees;
using HD.ProfileManager.JobPositions;
using HD.ProfileManager.OrganizationPositions;
using HD.ProfileManager.Organizations;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;

namespace HD.ProfileManager;

public class ProfileManagerApplicationAutoMapperProfile : Profile
{
    public ProfileManagerApplicationAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Organization, CreateOrganizationDto>();
        CreateMap<Organization, OrganizationDto>();
        CreateMap<Organization, OrganizationLookupDto>();

        CreateMap<JobPosition, JobPositionDto>();
        CreateMap<JobPosition, PositionLookupDto>();
        CreateMap<JobFamily, JobFamiliesLookupDto>();
        CreateMap<JobFamily, JobFamilyDto>();

        CreateMap<OrganizationPosition, OrganizationPositionDto>();

    }
}
