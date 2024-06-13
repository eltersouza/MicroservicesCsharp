using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.CourseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public IStudentRepository _studentRepository { get; }
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("/{studentId}")]
        public async Task<IActionResult> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if(student == null)
                return NotFound();

            return Ok(student);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] Student student)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            student = await _studentRepository.CreateAsync(student);

            return StatusCode(StatusCodes.Status201Created, student);
        }
    }
}
