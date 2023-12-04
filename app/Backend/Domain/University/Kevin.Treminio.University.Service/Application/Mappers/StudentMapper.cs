using AutoMapper;
using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;

namespace Kevin.Treminio.University.Service.Application.Mappers
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.BirthDate.GetAge()));
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();
            CreateMap<Student, StudentForUpdateDto>();
        }
    }
}
