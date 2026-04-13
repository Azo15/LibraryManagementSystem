using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadUserInfo();
            this.Load += (s, e) => btnHome.PerformClick();
        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            var user = AuthService.CurrentUser;
            if (user != null)
            {
                lblWelcome.Text = $"Hoş Geldiniz, {user.FullName}";
            }
            btnHome.PerformClick();
        }

        private void LoadUserInfo()
        {
            var user = AuthService.CurrentUser;
            lblWelcome.Text = $"Hoş Geldiniz, {user.FullName}";
        }

        private void LoadForm(Form form)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls[0].Dispose();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            this.panelContent.Controls.Add(form);
            this.panelContent.Tag = form;
            form.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            LoadForm(new BookManagementForm());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            LoadForm(new UserManagementForm());
        }

        private void btnBorrowTracking_Click(object sender, EventArgs e)
        {
            // Ödünç takip paneli için alt form açılacak. Şimdilik HomeForm yükleyebilir veya yeni form eklenebilir.
            // Bu form eklenecek.
            // LoadForm(new StaffBorrowManagementForm());
            Validators.InputValidator.ShowError("Ödünç takip sayfası yakında eklenecektir.");
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthService.Logout();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

