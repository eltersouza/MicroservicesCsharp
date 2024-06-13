using Aplication.DTOs;
using FluentValidation;

namespace Aplication.Validations
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(course => course.Title).NotEmpty();
        }
    }
}
