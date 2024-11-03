using AutoMapper;
using Core.Entitys;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, Employer>()
                .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Pension * 200));
        }
    }
}
