using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 
        public DateTime DeadLine { get; set; }
        public byte[] File { get; set; } = null!; 
        public Course? Course { get; set; }
        public int CourseId { get; set; }
        public ICollection<Solution>? Solutions { get; set; }
    }
}
