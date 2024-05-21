using Microsoft.AspNetCore.Mvc;
using School.Contract.Services;
using School.Services.Request;
using School.Services.ViewModel;

namespace School.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StudentVm>>> Get()
        {
            var students = await _studentServices.Get();
            return Ok(students);
        }
        [HttpGet("ById")]
        public async Task<ActionResult<StudentVm>> GetById(int id)
        {
            var student = await _studentServices.GetById(id);
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<StudentVm>> Post(StudentRequest request)
        {
            var student = await _studentServices.Post(request);
            return Ok(student);
        }
    }
}


