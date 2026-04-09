using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using LibraryManagementSystem.Database;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Validators;

namespace LibraryManagementSystem.Services
{
    public class AuthService
    {
        private static User currentUser;

        public static User CurrentUser
        {
            get { return currentUser; }
            private set { currentUser = value; }
        }

        public static bool Login(string email, string password)
        {
            if (!InputValidator.ValidateEmail(email, out string emailError))
            {
                InputValidator.ShowError(emailError);
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                InputValidator.ShowError("Şifre alanı boş bırakılamaz.");
                return false;
            }

            string hashedPassword = HashPassword(password);
            string query = @"
                SELECT Id, FirstName, LastName, Email, Password, SchoolNumber, Phone, Role, CreatedAt
                FROM Users
                WHERE Email = @email AND Password = @password";

            using (var reader = DatabaseHelper.ExecuteReader(query,
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", hashedPassword)))
            {
                if (reader.Read())
                {
                    CurrentUser = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        SchoolNumber = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Phone = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Role = (UserRole)reader.GetInt32(7),
                        CreatedAt = reader.GetDateTime(8)
                    };
                    return true;
                }
            }

            InputValidator.ShowError("E-posta veya şifre hatalı.");
            return false;
        }

        public static bool Register(string firstName, string lastName, string email, string password, 
            string schoolNumber, string phone)
        {
            // Validate all fields
            if (!InputValidator.ValidateRequired(firstName, "Ad", out string error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            if (!InputValidator.ValidateRequired(lastName, "Soyad", out error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            if (!InputValidator.ValidateEmail(email, out error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            if (!InputValidator.ValidatePassword(password, out error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            if (!InputValidator.ValidateRequired(schoolNumber, "Okul Numarası", out error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            if (!InputValidator.ValidatePhone(phone, out error))
            {
                InputValidator.ShowError(error);
                return false;
            }

            // Check if email already exists
            string checkEmail = "SELECT COUNT(*) FROM Users WHERE Email = @email";
            object result = DatabaseHelper.ExecuteScalar(checkEmail, new SQLiteParameter("@email", email));
            if (Convert.ToInt32(result) > 0)
            {
                InputValidator.ShowError("Bu e-posta adresi zaten kullanılıyor.");
                return false;
            }

            // Check if school number already exists
            string checkSchoolNumber = "SELECT COUNT(*) FROM Users WHERE SchoolNumber = @schoolNumber";
            result = DatabaseHelper.ExecuteScalar(checkSchoolNumber, new SQLiteParameter("@schoolNumber", schoolNumber));
            if (Convert.ToInt32(result) > 0)
            {
                InputValidator.ShowError("Bu okul numarası zaten kullanılıyor.");
                return false;
            }

            // Insert new user
            string hashedPassword = HashPassword(password);
            string insertQuery = @"
                INSERT INTO Users (FirstName, LastName, Email, Password, SchoolNumber, Phone, Role)
                VALUES (@firstName, @lastName, @email, @password, @schoolNumber, @phone, 1)";

            DatabaseHelper.ExecuteNonQuery(insertQuery,
                new SQLiteParameter("@firstName", firstName),
                new SQLiteParameter("@lastName", lastName),
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", hashedPassword),
                new SQLiteParameter("@schoolNumber", schoolNumber),
                new SQLiteParameter("@phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : (object)phone));

            InputValidator.ShowSuccess("Kayıt başarılı! Giriş yapabilirsiniz.");
            return true;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

