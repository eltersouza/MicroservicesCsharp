namespace Aplication.DTOs
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static Course FromEntity(Domain.Entities.Course courseEntity)
        {
            var course = new Course()
            {
                Id = courseEntity.Id,
                Description = courseEntity.Description,
                Title = courseEntity.Title
            };
            
            return course;
        }
    }
}
