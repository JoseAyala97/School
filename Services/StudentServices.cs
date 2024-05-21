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
                if (student == null)
                    throw new Exception("Student Not Found");
                
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
        public async Task<StudentVm> Put(int id, StudentRequest request)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                    throw new Exception("Not Found");
                if (request.Name != null)
                    student.Name = request.Name;                
                if (request.LastName != null)
                    student.LastName = request.LastName;               
                if (request.Age.HasValue)
                    student.Age = request.Age; 

                await _studentRepository.UpdateAsync(student);
                return _mapper.Map<StudentVm>(student);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
