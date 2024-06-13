using Aplication.DTOs;

namespace Core.FinanceService.Application.Interfaces.UseCases
{
    public interface IEnrollStudentToCourse
    {
        Task<Enrollment> EnrollmentAsync(Enrollment enrollment);
    }
}
