using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.FinanceService.Application.Interfaces.UseCases;

namespace Core.FinanceService.Application.UseCases
{
    public class EnrollStudentToCourse : IEnrollStudentToCourse
    {
        public readonly IEnrollmentRepository _enrollmentRepository;
        public readonly ICourseRepository _courseRepository;
        public readonly IStudentRepository _studentRepository;

        public EnrollStudentToCourse(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Enrollment> EnrollmentAsync(Enrollment enrollment)
        {
            enrollment.EnrolledAt = DateTime.UtcNow;

            var course = await _courseRepository.CreateAsync(enrollment.Course!);
            var student = await _studentRepository.CreateAsync(enrollment.Student!);

            enrollment.StudentId = student.Id;
            enrollment.Student = student;

            enrollment.CourseId = course.Id;
            enrollment.Course = course;

            enrollment = await _enrollmentRepository.CreateAsync(enrollment);

            return enrollment;
        }
    }
}
