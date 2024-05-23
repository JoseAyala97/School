using AutoMapper;
using School.Contract.Repositories;
using School.Contract.Services;
using School.Models.Entities;
using School.Services.Request;
using School.Services.ViewModel;

namespace School.Services
{
    public class CoursesServices : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CoursesServices(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }
        public async Task<IReadOnlyList<CourseVm>> Get()
        {
            try
            {
                var course = await _courseRepository.GetAsync(c => true);
                return _mapper.Map<IReadOnlyList<CourseVm>>(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseVm> GetById(int id)
        {
            try
            {
                var course = await _courseRepository.GetByIdAsync(id);
                if (course == null)
                {
                    throw new Exception("Not Found course");
                }
                return _mapper.Map<CourseVm>(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseVm> Post(CourseRequest request)
        {
            try
            {
                var course = new Course
                {
                    Name = request.Name,
                    Description = request.Description
                };
                await _courseRepository.InsertAsync(course);
                return _mapper.Map<CourseVm>(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseVm> Put(int id, CourseRequest request)
        {
            try
            {
                var course = await _courseRepository.GetByIdAsync(id);
                if (course == null)
                    throw new Exception("Course Not Found");
                if (request.Name != null)
                    course.Name = request.Name;
                if (request.Description != null)
                    course.Description = request.Description;
                await _courseRepository.UpdateAsync(course);
                return _mapper.Map<CourseVm>(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
