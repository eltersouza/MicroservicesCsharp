using Aplication.DTOs;

namespace Core.CourseService.Aplication.Interfaces.UseCases
{
    public interface IEnrollStudentToCourse
    {
        Task<Enrollment> EnrollmentAsync(Enrollment enrollment);
    }
}
