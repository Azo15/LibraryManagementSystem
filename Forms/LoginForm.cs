using System;
using System.Windows.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (AuthService.Login(email, password))
            {
                // Open appropriate dashboard based on user role
                Form dashboard = null;
                switch (AuthService.CurrentUser.Role)
                {
                    case Models.UserRole.Student:
                        dashboard = new StudentDashboard();
                        break;
                    case Models.UserRole.Staff:
                        dashboard = new StaffDashboard();
                        break;
                    case Models.UserRole.Admin:
                        dashboard = new AdminDashboard();
                        break;
                }

                if (dashboard != null)
                {
                    this.Hide();
                    dashboard.ShowDialog();
                    this.Close();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }
    }
}

