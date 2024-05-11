namespace HandwrittenTextRecognitionSystem.Consts
{
    public static class AppRegexs
    {
        public const string Password = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\\W)(?!.*\\s).{6,}$";
        public const string Username = "^[a-zA-Z0-9]{4,10}$";
        public const string Phone = "^01[0125]{1}[0-9]{8}$";
    }
}
