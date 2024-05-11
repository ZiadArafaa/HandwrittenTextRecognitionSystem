namespace HandwrittenTextRecognitionSystem.Models
{
    public class Solution
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public byte[] File { get; set; } = null!;
        public Assignment? Assignment { get; set; }
        public int AssignmentId { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
    }
}
