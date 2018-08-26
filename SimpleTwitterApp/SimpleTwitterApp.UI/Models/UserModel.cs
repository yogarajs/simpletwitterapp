namespace SimpleTwitterApp.UI.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
    }
}