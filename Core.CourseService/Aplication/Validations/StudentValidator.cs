using Aplication.DTOs;
using FluentValidation;

namespace Aplication.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Name).NotEmpty();
            RuleFor(student => student.Email).EmailAddress();
        }
    }
}