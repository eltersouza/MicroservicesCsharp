using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Core.CourseService.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public PostgresDbContext _dbContext { get; }
        public StudentRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student> Create(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return null;

            var studentDto = Student.FromEntity(student);
            return studentDto;
        }
    }
}
