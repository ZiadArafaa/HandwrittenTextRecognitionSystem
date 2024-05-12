using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(6)]
        public string Code { get; set; } = null!;
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public ICollection<Assignment>? Assignments { get; set; }
        public int DoctorId { get; set; }
        public Teacher? Doctor { get; set; }
    }
}
