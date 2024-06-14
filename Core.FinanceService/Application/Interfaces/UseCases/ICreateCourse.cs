using Aplication.DTOs;

namespace Core.FinanceService.Application.Interfaces.UseCases
{
    public interface ICreateCourse
    {
        Task<Course> CreateAsync(Enrollment enroll);
    }
}
