using Domain.Entities;

namespace Aplication.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        public Task<Course> Create(Course course);
        public Task<Course> GetById(int id);
        public Task<IEnumerable<Course>> GetAll();
    }
}
