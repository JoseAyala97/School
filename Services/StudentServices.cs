using AutoMapper;
using School.Contract.Repositories;
using School.Contract.Services;
using School.Models.Entities;
using School.Services.Request;
using School.Services.ViewModel;

namespace School.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentServices(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<StudentVm>> Get()
        {
            try
            {
                var students = await _studentRepository.GetAsync(s => true);
                var studentsResponse = _mapper.Map<IReadOnlyList<StudentVm>>(students);
                return studentsResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<StudentVm> GetById(int id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                var studentResponse = _mapper.Map<StudentVm>(student);
                return studentResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<StudentVm> Post(StudentRequest request)
        {
            try
            {
                var student = new Student
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Age = request.Age
                };

                await _studentRepository.InsertAsync(student);
                var studentVm = _mapper.Map<StudentVm>(student);
                return studentVm;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
