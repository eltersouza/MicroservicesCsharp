using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.CourseService.Aplication.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.CourseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        public readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IEnrollStudentToCourse _enrollStudentToCourse;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository, IEnrollStudentToCourse enrollStudentToCourse) 
        {
            _enrollmentRepository = enrollmentRepository;
            _enrollStudentToCourse = enrollStudentToCourse;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollmentsAsync() 
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();

            return Ok(enrollments);
        }

        [HttpGet]
        [Route("/{enrollmentId}")]
        public async Task<IActionResult> GetEnrollmentById(int enrollmentId)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
            if(enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollmentAsync([FromBody] Enrollment enrollmentModel)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var enrollment = await _enrollStudentToCourse.EnrollmentAsync(enrollmentModel);

            return StatusCode(StatusCodes.Status201Created, enrollment);
        }
    }
}
