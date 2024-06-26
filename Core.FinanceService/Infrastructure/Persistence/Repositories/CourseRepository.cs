﻿using Aplication.DTOs;
using Aplication.Interfaces.Repositories;
using Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly PostgresDbContext _dbContext;

        public CourseRepository(IDbContextFactory<PostgresDbContext> myDbContextFactory)
        {
            _dbContext = myDbContextFactory.CreateDbContext();
        }

        public async Task<Course> CreateAsync(Course course)
        {
            var courseEntity = new Domain.Entities.Course
            {
                Description = course.Description,
                Title = course.Title
            };

            _dbContext.Courses.Add(courseEntity);

            await _dbContext.SaveChangesAsync();

            return Course.FromEntity(courseEntity);
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var courseEntity = await _dbContext.Courses.SingleOrDefaultAsync(x => x.Id == id);
            
            return courseEntity != null ? Course.FromEntity(courseEntity) : null;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return courses.Select(courseEntity => Course.FromEntity(courseEntity));
        }
    }
}