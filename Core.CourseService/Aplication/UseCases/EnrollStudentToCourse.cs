using Aplication.DTOs;
using Aplication.Interfaces.Messaging;
using Aplication.Interfaces.Repositories;
using Core.CourseService.Aplication.Interfaces.UseCases;

namespace Core.CourseService.Aplication.UseCases
{
    public class EnrollStudentToCourse : IEnrollStudentToCourse
    {
        public readonly IEnrollmentRepository _enrollmentRepository;
        public readonly ICourseRepository _courseRepository;
        public readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentDataPublisher _enrollmentDataPublisher;

        public EnrollStudentToCourse(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository, IEnrollmentDataPublisher enrollmentDataPublisher)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _enrollmentDataPublisher = enrollmentDataPublisher;
        }

        public async Task<Enrollment> EnrollmentAsync(Enrollment enrollment)
        {
            enrollment.EnrolledAt = DateTime.UtcNow;
            enrollment = await _enrollmentRepository.CreateAsync(enrollment);

            enrollment.Course = await _courseRepository.GetByIdAsync(enrollment.CourseId);
            enrollment.Student = await _studentRepository.GetByIdAsync(enrollment.StudentId);

            var publishResult = await _enrollmentDataPublisher.PublishAsync(enrollment);

            return enrollment;
        }
    }
}
