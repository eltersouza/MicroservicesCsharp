using Newtonsoft.Json;
using System.Text.Json;

namespace Aplication.DTOs
{
    public class Enrollment
    {
        public int? Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }

        public static Enrollment FromEntity(Domain.Entities.Enrollment entity)
        {
            var enrollment = new Enrollment() { 
                CourseId = entity.CourseId, 
                Course = entity.Course != null ? Course.FromEntity(entity.Course) : null,
                StudentId = entity.StudentId,
                Student = entity.Student != null ? Student.FromEntity(entity.Student) : null,
                EnrolledAt = entity.EnrolledAt,
            };

            return enrollment;
        }

        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
