namespace HandwrittenTextRecognitionSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser? ApplicationUser { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
