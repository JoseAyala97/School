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
            => Ok(await _studentServices.Get());
        [HttpGet("ById")]
        public async Task<ActionResult<StudentVm>> GetById(int id)
            => Ok(await _studentServices.GetById(id));
        [HttpPost]
        public async Task<ActionResult<StudentVm>> Post(StudentRequest request)
            => Ok(await _studentServices.Post(request));
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentVm>> Put(int id, [FromBody] StudentRequest request)
            => Ok(await _studentServices.Put(id, request));
    }
}
