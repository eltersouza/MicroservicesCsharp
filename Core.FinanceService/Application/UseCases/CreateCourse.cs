using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.FinanceService.Application.Interfaces.UseCases;
using FluentValidation;

namespace Core.FinanceService.Application.UseCases
{
    public class CreateCourse : ICreateCourse
    {
        public readonly ICourseRepository _courseRepository;
        public readonly IValidator<Course> _courseValidator;

        public CreateCourse(ICourseRepository courseRepository, IValidator<Course> courseValidator)
        {
            _courseRepository = courseRepository;
            _courseValidator = courseValidator;
        }

        public async Task<Course> CreateAsync(Enrollment enroll)
        {
            var courseValidation = _courseValidator.Validate(enroll.Course!);
            if (!courseValidation.IsValid)
                return null;

            var course = await _courseRepository.CreateAsync(enroll.Course);
            return course;
        }
    }
}
