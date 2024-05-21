using Microsoft.AspNetCore.Mvc;
using School.Contract.Services;
using School.Services.Request;
using School.Services.ViewModel;

namespace School.Controllers
{
    [ApiController]
    [Route("api/teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherServices _teacherServices;

        public TeacherController(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TeacherVm>>> Get()
        {
            var teachers = await _teacherServices.Get();
            return Ok(teachers);
        }
        [HttpGet("ById")]
        public async Task<ActionResult<TeacherVm>> GetById(int id)
        {
            var teacher = await _teacherServices.GetById(id);
            return Ok(teacher);
        }
        [HttpPost]
        public async Task<ActionResult<TeacherVm>> Post(TeacherRequest request)
        {
            var teacher = await _teacherServices.Post(request);
            return Ok(teacher);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherVm>> Put(int id, [FromBody] TeacherRequest request)
        {
            var teacher = await _teacherServices.Put(id, request);
            return Ok(teacher);
        }
    }
}
