using System;
using System.Windows.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadUserInfo();
            this.Load += (s, e) => btnReports.PerformClick();
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

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            LoadForm(new BookManagementForm());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            LoadForm(new UserManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportsForm());
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

