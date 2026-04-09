using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LibraryManagementSystem.Validators
{
    public static class InputValidator
    {
        public static bool ValidateRequired(string value, string fieldName, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = $"{fieldName} alanı boş bırakılamaz.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateEmail(string email, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "E-posta alanı boş bırakılamaz.";
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                errorMessage = "Geçerli bir e-posta adresi giriniz.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidatePassword(string password, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Parola alanı boş bırakılamaz.";
                return false;
            }

            if (password.Length < 8)
            {
                errorMessage = "Parola en az 8 karakter olmalıdır.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                errorMessage = "Parola en az bir büyük harf içermelidir.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                errorMessage = "Parola en az bir küçük harf içermelidir.";
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                errorMessage = "Parola en az bir rakam içermelidir.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidatePhone(string phone, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                errorMessage = string.Empty;
                return true; // Phone is optional
            }

            string pattern = @"^[0-9]{10,11}$";
            if (!Regex.IsMatch(phone.Replace(" ", "").Replace("-", ""), pattern))
            {
                errorMessage = "Geçerli bir telefon numarası giriniz (10-11 haneli).";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static bool ValidateNumeric(string value, string fieldName, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                errorMessage = $"{fieldName} alanı boş bırakılamaz.";
                return false;
            }

            if (!int.TryParse(value, out _))
            {
                errorMessage = $"{fieldName} sayısal bir değer olmalıdır.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowConfirmation(string message)
        {
            return MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}

