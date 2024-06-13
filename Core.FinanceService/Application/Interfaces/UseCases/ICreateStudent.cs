using Aplication.DTOs;

namespace Core.FinanceService.Application.Interfaces.UseCases;

public interface ICreateStudent
{
    Task<Student> CreateAsync(Enrollment enroll);
}