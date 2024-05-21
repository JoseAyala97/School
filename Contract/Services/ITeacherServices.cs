using School.Services.Request;
using School.Services.ViewModel;

namespace School.Contract.Services
{
    public interface ITeacherServices
    {
        Task<IReadOnlyList<TeacherVm>> Get();
        Task<TeacherVm> GetById(int id);
        Task<TeacherVm> Post(TeacherRequest request);
        Task<TeacherVm> Put(int id, TeacherRequest request);
    }
}
