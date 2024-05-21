using School.Contract.Repositories;
using School.Contract.Services;
using School.Services.ViewModel;

namespace School.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentVm> GetStudents()
        {

        }
    }
}
