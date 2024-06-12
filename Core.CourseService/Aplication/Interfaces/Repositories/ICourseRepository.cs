using Aplication.DTOs;

namespace Aplication.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        public Task<Course> CreateAsync(Course course);
        public Task<Course?> GetByIdAsync(int id);
        public Task<IEnumerable<Course>> GetAllAsync();
    }
}