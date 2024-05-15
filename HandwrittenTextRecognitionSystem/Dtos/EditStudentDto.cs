using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class EditStudentDto : EditUserDto
    {
        public int DepartmentId { get; set; }
        [AssertThat("Level >=1 && Level <=4", ErrorMessage = "{0} Must be From One To Four.")]
        public int Level { get; set; }
    }
}
