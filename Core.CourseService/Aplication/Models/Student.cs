namespace Aplication.DTOs
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public static Student FromEntity(Domain.Entities.Student studentEntity)
        {
            var student = new Student();
            student.Id = studentEntity.Id;
            student.Name = studentEntity.Name;
            student.Email = studentEntity.Email;
            student.Country = studentEntity.Country;

            return student;
        }
    }
}
