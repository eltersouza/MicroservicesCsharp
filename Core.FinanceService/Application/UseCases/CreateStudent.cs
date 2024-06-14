using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.FinanceService.Application.Interfaces.UseCases;
using FluentValidation;

namespace Core.FinanceService.Application.UseCases
{
    public class CreateStudent : ICreateStudent
    {
        public readonly IStudentRepository _studentRepository;
        public readonly IValidator<Student> _studentValidator;

        public CreateStudent(IStudentRepository studentRepository, IValidator<Student> studentValidator)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
        }
        public async Task<Student> CreateAsync(Enrollment enroll)
        {
            var studentValidation = _studentValidator.Validate(enroll.Student!);
            if (!studentValidation.IsValid)
                return null;

            var student = await _studentRepository.CreateAsync(enroll.Student);
            return student;
        }
    }
}

