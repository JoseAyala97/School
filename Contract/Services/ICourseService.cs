using School.Services.Request;
using School.Services.ViewModel;

namespace School.Contract.Services
{
    public interface ICourseService
    {
        Task<IReadOnlyList<CourseVm>> Get();
        Task<CourseVm> GetById(int id);
        Task<CourseVm> Post(CourseRequest request);
        Task<CourseVm> Put(int id, CourseRequest request);
    }
}
