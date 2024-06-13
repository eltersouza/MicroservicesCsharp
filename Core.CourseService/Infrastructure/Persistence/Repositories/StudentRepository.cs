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

        public async Task<Student> CreateAsync(Student student)
        {
            Domain.Entities.Student studentEntity = new Domain.Entities.Student()
            {
                Email = student.Email,
                Name = student.Name
            };

            _dbContext.Students.Add(studentEntity);

            await _dbContext.SaveChangesAsync();
            
            return Student.FromEntity(studentEntity);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var students = await _dbContext.Students.ToListAsync();
            
            return students.Select((student, i) => Student.FromEntity(student));
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var studentEntity = await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id);

            return studentEntity != null ? Student.FromEntity(studentEntity) : null;
        }
    }
}
