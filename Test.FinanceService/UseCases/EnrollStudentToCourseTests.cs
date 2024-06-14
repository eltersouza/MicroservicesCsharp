

using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Core.FinanceService.Application.Interfaces.UseCases;
using Core.FinanceService.Application.Strategy.Concretes;
using Core.FinanceService.Application.UseCases;
using Moq;

namespace Test.FinanceService
{
    public class EnrollStudentToCourseTests
    {
        [Fact]
        public void GivenEnrollment_WhenStudentIsBrazilian_ThenMakeEnrollmentWithRealCost()
        {
            //Arrange
            Moq.Mock<IEnrollmentRepository> _enrollRepositoryMock = new Mock<IEnrollmentRepository>();
            _enrollRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Enrollment() { Id = 1, StudentId = 1, CourseId = 1 }));

            Moq.Mock<ICreateCourse> _createCourseMock = new Mock<ICreateCourse>();
            _createCourseMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Course() { Id = 1, Title = "Teste", Description = "Teste Desc" }));

            Moq.Mock<ICreateStudent> _createStudentMock = new Mock<ICreateStudent>();
            _createStudentMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Student()
                    { Id = 1, Name = "Student Test", Email = "student.test@gmail.com" }));

            IEnrollStudentToCourse enrollStudentToCourse = new EnrollStudentToCourse(_enrollRepositoryMock.Object,
                _createCourseMock.Object, _createStudentMock.Object);

            //Act
            var enrollment = new Enrollment()
            {
                StudentId = 1,
                Student = new Student()
                {
                    Id = 1,
                    Name = "Elter",
                    Email = "elter.souza@thoughtworks.com",
                    Country = "BR"
                },
                CourseId = 1
            };

            string cost = enrollStudentToCourse.GetCosts(enrollment);

            //Assert
            Assert.Equal("R$125,00 BRL", cost);
        }
        
        [Theory]
        [InlineData(["BR", "R$125,00 BRL"])]
        [InlineData(["USA", "$32.00 USD"])]
        [InlineData(["USA", "$32.00 USD"])]
        [InlineData(["", null])]
        [InlineData(["IT", null])]
        [InlineData(["JP", null])]
        public void GivenEnrollment_WhenStudentIsBrazilian_ThenGetCostAppropriately(string country, string expectedValue)
        {
            //Arrange
            Moq.Mock<IEnrollmentRepository> _enrollRepositoryMock = new Mock<IEnrollmentRepository>();
            _enrollRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Enrollment() { Id = 1, StudentId = 1, CourseId = 1 }));

            Moq.Mock<ICreateCourse> _createCourseMock = new Mock<ICreateCourse>();
            _createCourseMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Course() { Id = 1, Title = "Teste", Description = "Teste Desc" }));

            Moq.Mock<ICreateStudent> _createStudentMock = new Mock<ICreateStudent>();
            _createStudentMock.Setup(x => x.CreateAsync(It.IsAny<Enrollment>()))
                .Returns(() => Task.Run(() => new Student()
                    { Id = 1, Name = "Student Test", Email = "student.test@gmail.com" }));

            IEnrollStudentToCourse enrollStudentToCourse = new EnrollStudentToCourse(_enrollRepositoryMock.Object,
                _createCourseMock.Object, _createStudentMock.Object);

            //Act
            var enrollment = new Enrollment()
            {
                StudentId = 1,
                Student = new Student()
                {
                    Id = 1,
                    Name = "Elter",
                    Email = "elter.souza@thoughtworks.com",
                    Country = country
                },
                CourseId = 1
            };

            string cost = enrollStudentToCourse.GetCosts(enrollment);

            //Assert
            Assert.Equal(expectedValue, cost);
        }
    }
}