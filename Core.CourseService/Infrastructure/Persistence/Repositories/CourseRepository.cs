using Aplication.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task<Course> Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> FindCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
