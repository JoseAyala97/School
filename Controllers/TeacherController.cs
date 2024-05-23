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
            => Ok(await _teacherServices.Get());
        [HttpGet("ById")]
        public async Task<ActionResult<TeacherVm>> GetById(int id)
            => Ok(await _teacherServices.GetById(id));
        [HttpPost]
        public async Task<ActionResult<TeacherVm>> Post(TeacherRequest request)
            => Ok(await _teacherServices.Post(request));
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherVm>> Put(int id, [FromBody] TeacherRequest request)
            => Ok(await _teacherServices.Put(id, request));
    }
}
