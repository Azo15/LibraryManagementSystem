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
        }

        private void LoadUserInfo()
        {
            var user = AuthService.CurrentUser;
            lblWelcome.Text = $"Hoş Geldiniz, {user.FullName}";
            
            // Add tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnSearchBooks, "Kütüphanedeki tüm kitapları arayın ve inceleyin.");
            toolTip.SetToolTip(btnBorrowRequest, "Seçtiğiniz bir kitap için ödünç alma talebi gönderin.");
            toolTip.SetToolTip(btnTrackBorrows, "Mevcut ödünç taleplerinizin durumunu (Onaylı, Bekleyen vb.) takip edin.");
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

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            LoadForm(new BookSearchForm());
        }

        private void btnBorrowRequest_Click(object sender, EventArgs e)
        {
            BorrowRequestForm requestForm = new BorrowRequestForm();
            if (requestForm.ShowDialog() == DialogResult.OK)
            {
                Validators.InputValidator.ShowSuccess("Talep başarıyla gönderildi.");
            }
        }

        private void btnTrackBorrows_Click(object sender, EventArgs e)
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

