using Aplication.DTOs;

namespace Aplication.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        public Task<Student> Create(Student student);
        public Task<Student> GetByIdAsync(int id);
        public Task<IEnumerable<Student>> GetAll();
    }
}
