using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Aplication.Validations;
using Core.FinanceService.Application.Interfaces.UseCases;
using Core.FinanceService.Application.UseCases;
using Moq;

namespace Test.FinanceService
{
    public class CreateStudentTests
    {
        [Fact]
        public async Task GivenEnrollment_WhenCreateStudent_ThenReturnNewStudent()
        {
            //Arrange
            // Moq.Mock<ICreateStudent> mockCreateStudent = new Mock<ICreateStudent>();
            // mockCreateStudent.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()));
            
            Moq.Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.CreateAsync(It.IsAny<Student>()))
                .Returns(() => Task.Run(() => new Student{Id = 1, Email = "teste@test.com", Name = "Test"}));

            ICreateStudent createStudent = new CreateStudent(mockStudentRepository.Object, new StudentValidator());

            //Act
            var enrollment = new Enrollment()
            {
                CourseId = 1,
                StudentId = 2,
                Student = new Student() { Name = "Elter", Email = "elter@test.com" }
            };

            var student = await createStudent.CreateAsync(enrollment);

            //Assert
            Assert.NotNull(student);
        }
        
        [Fact]
        public async Task GivenEnrollment_WhenCreateStudent_ThenReturnNull()
        {
            //Arrange
            Moq.Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(x => x.CreateAsync(It.IsAny<Student>()))
                .Returns(() => Task.Run(() => new Student{Id = 1, Email = "teste@test.com", Name = "Test"}));

            ICreateStudent createStudent = new CreateStudent(mockStudentRepository.Object, new StudentValidator());

            //Act
            var enrollment = new Enrollment()
            {
                CourseId = 1,
                StudentId = 2,
                Student = new Student() { Name = "Elter", Email = "elter" }
            };

            var student = await createStudent.CreateAsync(enrollment);

            //Assert
            Assert.Null(student);
        }
    }
}
