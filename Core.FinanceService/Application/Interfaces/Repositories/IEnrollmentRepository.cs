using Aplication.DTOs;

namespace Aplication.Interfaces.Repositories
{
    public interface IEnrollmentRepository
    {
        public Task<Enrollment> CreateAsync(Enrollment enrollment);
        public Task<Enrollment?> GetByIdAsync(int id);
        public Task<IEnumerable<Enrollment>> GetAllAsync();
    }
}
