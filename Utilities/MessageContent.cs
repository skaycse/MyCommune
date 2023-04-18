namespace MyCommune.Utilities
{
    public static class MessageInfo
    {
        public class Account
        {
            public const string EmailAlreadyRegistered = "This Email is already registered in our system.";
            public const string InValidCredentials = "Username or Password is invalid.";
            public const string InValidEmail = "Email is not registered with system.";
        }

        public class User
        {
            public const string EmailAlreadyAssociated = "This Email is already associated with another user.";
            public const string MobileAlreadyAssociated = "This Mobile is already associated with another user.";
        }
    }
}
