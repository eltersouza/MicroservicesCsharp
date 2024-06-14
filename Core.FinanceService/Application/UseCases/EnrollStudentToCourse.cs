using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.FinanceService.Application.Enums;
using Core.FinanceService.Application.Interfaces.UseCases;
using Core.FinanceService.Application.Strategy;

namespace Core.FinanceService.Application.UseCases
{
    public class EnrollStudentToCourse : IEnrollStudentToCourse
    {
        public readonly IEnrollmentRepository _enrollmentRepository;
        public readonly ICreateCourse _createCourse;
        public readonly ICreateStudent _createStudent;

        public EnrollStudentToCourse(IEnrollmentRepository enrollmentRepository, ICreateCourse createCourse, ICreateStudent createStudent)
        {
            _enrollmentRepository = enrollmentRepository;
            _createCourse = createCourse;
            _createStudent = createStudent;
        }

        public async Task<Enrollment> EnrollmentAsync(Enrollment enrollment)
        {
            enrollment.EnrolledAt = DateTime.UtcNow;
            enrollment = await _enrollmentRepository.CreateAsync(enrollment);

            return enrollment;
        }

        public async Task<Enrollment> CreateResourcesAsync(Enrollment enrollment)
        {
            enrollment.Course = await _createCourse.CreateAsync(enrollment);
            enrollment.CourseId = enrollment.Course.Id;
                
            enrollment.Student = await _createStudent.CreateAsync(enrollment);
            enrollment.StudentId = enrollment.Student.Id;

            return enrollment;
        }

        public string GetCosts(Enrollment enrollment)
        {
            CostStrategyBuilder costStrategy;
            switch (enrollment.Student!.Country)
            {
                case "BR":
                    costStrategy = new CostStrategyBuilder(StrategyEnum.Real);
                    break;
                case "USA":
                    costStrategy = new CostStrategyBuilder(StrategyEnum.Dolar);
                    break;
                default:
                    costStrategy = new CostStrategyBuilder(StrategyEnum.Euro);
                    break;
            }
            
            return costStrategy.Execute();
        }
    }
}
