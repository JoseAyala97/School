using School.Services.Request;
using School.Services.ViewModel;

namespace School.Contract.Services
{
    public interface IStudentServices
    {
        Task<IReadOnlyList<StudentVm>> Get();
        Task<StudentVm> GetById(int id);
        Task<StudentVm> Post(StudentRequest request);
        Task<StudentVm> Put(int id, StudentRequest request);
    }
}
