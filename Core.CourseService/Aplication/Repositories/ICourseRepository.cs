using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repositories
{
    public interface ICourseRepository
    {
        public Task<Course> Create(Course course);
        public Task<Course> FindCourseById(int id);
        public Task<IEnumerable<Course>> GetAll();
    }
}
