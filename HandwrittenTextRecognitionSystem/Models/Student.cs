using HandwrittenTextRecognitionSystem.Consts;

namespace HandwrittenTextRecognitionSystem.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public int Level { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser? ApplicationUser { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Solution>? Solutions { get; set; }
    }
}
