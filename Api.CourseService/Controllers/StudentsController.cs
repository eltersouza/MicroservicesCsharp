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

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if(student == null)
                return NotFound();

            return Ok(student);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            if(!students.Any())
                return NotFound();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                return BadRequest();
            
            student = await _studentRepository.CreateAsync(student);

            return Ok(student);
        }
    }
}
