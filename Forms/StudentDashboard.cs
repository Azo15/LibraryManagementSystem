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

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            BookSearchForm searchForm = new BookSearchForm();
            searchForm.ShowDialog();
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
            BorrowTrackingForm trackingForm = new BorrowTrackingForm();
            trackingForm.ShowDialog();
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

