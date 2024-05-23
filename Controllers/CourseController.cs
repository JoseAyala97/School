using Microsoft.AspNetCore.Mvc;
using School.Contract.Services;
using School.Models.Entities;
using School.Services.Request;
using School.Services.ViewModel;

namespace School.Controllers
{
    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CourseVm>>> Get()
            => Ok(await _courseService.Get());
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseVm>> GetById(int id)
            => Ok(await _courseService.GetById(id));
        [HttpPost]
        public async Task<ActionResult<CourseVm>> Post(CourseRequest request)
            => Ok(await _courseService.Post(request));
        [HttpPut]
        public async Task<ActionResult<CourseVm>> Put(int id, CourseRequest request) 
            => Ok(await _courseService.Put(id, request));
    }
}
