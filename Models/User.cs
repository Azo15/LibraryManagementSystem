using System;

namespace LibraryManagementSystem.Models
{
    public enum UserRole
    {
        Student = 1,
        Staff = 2,
        Admin = 3
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SchoolNumber { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}

