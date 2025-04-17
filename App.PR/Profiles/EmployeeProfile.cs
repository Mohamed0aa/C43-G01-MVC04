using App.Buss.DTO;
using App.Data.Models;
using AutoMapper;

namespace App.PR.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
            //.ForMember(d=>d.Dept_id,o=>o.MapFrom(s=>s.) );
            CreateMap<CreateDepartmnetDto, Department>().ReverseMap();
        }
    }
}
