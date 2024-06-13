using Aplication.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CourseService.Aplication.Validations
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>
    {
        public EnrollmentValidator()
        {
            RuleFor(enrollment => enrollment.StudentId).NotEmpty();
            RuleFor(enrollment => enrollment.CourseId).NotEmpty();
        }
    }
}
