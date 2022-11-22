using AutoMapper;
using HD.ProfileManager.Employees;

namespace HD.ProfileManager;

public class ProfileManagerApplicationAutoMapperProfile : Profile
{
    public ProfileManagerApplicationAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    }
}
