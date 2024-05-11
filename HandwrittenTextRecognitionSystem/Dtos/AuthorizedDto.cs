namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class AuthorizedDto
    {
        public bool IsAuthenticated { get; set; }
        public IList<string>? Roles { get; set;}
        public string? Token { get; set; }  
        public DateTime ExpireOn { get; set; }
    }
}
