using Aplication.DTOs;

namespace Aplication.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        public Task<Student> CreateAsync(Student student);
        public Task<Student?> GetByIdAsync(int id);
        public Task<IEnumerable<Student>> GetAllAsync();
    }
}
