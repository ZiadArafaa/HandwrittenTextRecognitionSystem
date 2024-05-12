using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Doctors { get; set; }
    }
}
