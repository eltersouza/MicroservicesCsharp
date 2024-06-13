using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Core.CourseService.Infrastructure.Persistence.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly PostgresDbContext _dbContext;
        public EnrollmentRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Enrollment> CreateAsync(Enrollment enrollment)
        {
            var enrollmentEntity = new Domain.Entities.Enrollment
            {
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
                EnrolledAt = enrollment.EnrolledAt,
            };

            _dbContext.Enrollments.Add(enrollmentEntity);

            await _dbContext.SaveChangesAsync();

            return Enrollment.FromEntity(enrollmentEntity);
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            var enrollments = await _dbContext.Enrollments.ToListAsync();

            return enrollments.Select(enrollment => Enrollment.FromEntity(enrollment));
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            var enrollmentEntity = await _dbContext.Enrollments.SingleOrDefaultAsync(x => x.Id == id);

            return enrollmentEntity != null ? Enrollment.FromEntity(enrollmentEntity) : null;
        }
    }
}