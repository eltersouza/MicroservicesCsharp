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
    }
}
