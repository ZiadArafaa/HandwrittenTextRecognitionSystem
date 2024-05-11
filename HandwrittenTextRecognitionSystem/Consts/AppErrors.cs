namespace HandwrittenTextRecognitionSystem.Consts
{
    public static class AppErrors
    {
        public const string MaxLength = "{0} max length must be {1}.";
        public const string DataWrong = "Data could be wrong!";
        public const string PasswordRegex = "Passwords contain an uppercase character," +
            "lowercase character, a digit, and a non-alphanumeric character. Passwords must be at least six characters long.";
        public const string UsernameRegex = "Username must contain at least four letters and number only.";
        public const string ComparePassword = "Password not match.";
        public const string RoleValues = "Role can be Doctor ,Assistant or Student only.";
        public const string Phone = "Not valid phone number.";
        public const string ValidateImage = "check image size must be less than 2 MB and extensions allowed .jpg ,.png or .jpeg";
        public const string DatabaseFailure = "...Oops Database Failure Occured !";
    }
}
