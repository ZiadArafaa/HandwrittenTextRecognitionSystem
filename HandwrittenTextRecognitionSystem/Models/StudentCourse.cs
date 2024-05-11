using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Models
{
    
    public class StudentCourse
    {
        public Course? Course { get; set;}
        public int CourseId { get; set;}
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
