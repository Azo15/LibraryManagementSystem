using System;
using System.Windows.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadUserInfo();
            this.Load += (s, e) => btnHome.PerformClick();
        }

        private void LoadUserInfo()
        {
            var user = AuthService.CurrentUser;
            lblWelcome.Text = $"Hoş Geldiniz, {user.FullName}";
            
            // Add tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnSearchBooks, "Kütüphanedeki tüm kitapları arayın ve inceleyin.");
            toolTip.SetToolTip(btnMyBorrows, "Mevcut ödünç taleplerinizin durumunu (Onaylı, Bekleyen vb.) takip edin.");
            toolTip.SetToolTip(btnLogout, "Oturumu güvenli bir şekilde kapatır.");
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

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            LoadForm(new BookSearchForm());
        }

        private void btnMyBorrows_Click(object sender, EventArgs e)
        {
            LoadForm(new BorrowTrackingForm());
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

