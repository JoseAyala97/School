using AutoMapper;
using School.Models.Entities;
using School.Services.ViewModel;

namespace School.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Student, StudentVm>();

            CreateMap<Teacher, TeacherVm>();
        
        }
    }
}
