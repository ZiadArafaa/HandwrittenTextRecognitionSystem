namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class AuthorizedDto
    {
        public IList<string>? Roles { get; set;}
        public string? Token { get; set; }  
        public DateTime ExpireOn { get; set; }
    }
}
