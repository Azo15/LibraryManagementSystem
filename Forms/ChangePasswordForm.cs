using System;
using System.Windows.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                Validators.InputValidator.ShowError("Tüm alanları doldurunuz.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                Validators.InputValidator.ShowError("Yeni şifreler eşleşmiyor.");
                return;
            }

            if (!Validators.InputValidator.ValidatePassword(newPassword, out string passwordError))
            {
                Validators.InputValidator.ShowError(passwordError);
                return;
            }

            var user = AuthService.CurrentUser;
            if (!AuthService.VerifyPassword(currentPassword, user.Password))
            {
                Validators.InputValidator.ShowError("Mevcut şifrenizi yanlış girdiniz.");
                return;
            }

            AuthService.UpdatePassword(user.Id, newPassword);
            
            // Refresh currentUser password in memory
            typeof(AuthService).GetProperty("CurrentUser").SetValue(null, 
                new Models.User {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = AuthService.HashPassword(newPassword),
                    SchoolNumber = user.SchoolNumber,
                    Phone = user.Phone,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt
                });

            Validators.InputValidator.ShowSuccess("Şifreniz başarıyla güncellendi.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
