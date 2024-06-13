using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.CourseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        public ICourseRepository _courseRepository { get; }
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("/{courseId}")]
        public async Task<IActionResult> GetCourseByIdAsync(int courseId)
        {
            var student = await _courseRepository.GetByIdAsync(courseId);
            if(student == null)
                return NotFound();

            return Ok(student);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var students = await _courseRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync([FromBody] Course course)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            course = await _courseRepository.CreateAsync(course);

            return StatusCode(StatusCodes.Status201Created, course);
        }
    }
}
