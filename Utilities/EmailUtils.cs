namespace MyCommune.Utilities
{
    public class EmailUtils
    {
        public class EmailSubjects
        {
            public const string ForgotEmailSubject = "ForgotPassword";
        }

        public class EmailBody
        {
            public const string ForgotEmailBody = "Please click this <a href=\"{0}\">link</a> to change your password.";
        }
    }
}
