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
            LoadBorrowRequests();
            LoadDailySummary();
        }

        private void LoadUserInfo()
        {
            var user = AuthService.CurrentUser;
            lblWelcome.Text = $"Hoş Geldiniz, {user.FullName}";
        }

        private void LoadBorrowRequests()
        {
            dgvRequests.Rows.Clear();
            BorrowService.CheckOverdueBooks();
            
            var requests = BorrowService.GetAllBorrowRequests();
            foreach (var request in requests)
            {
                dgvRequests.Rows.Add(
                    request.Id,
                    request.UserName,
                    request.BookTitle,
                    request.RequestDate.ToString("dd.MM.yyyy"),
                    request.StatusText
                );
            }
        }

        private void LoadDailySummary()
        {
            DateTime today = DateTime.Now;
            int dailyBorrows = ReportService.GetDailyBorrowCount(today);
            int dailyReturns = ReportService.GetDailyReturnCount(today);
            int overdueCount = ReportService.GetOverdueCount();

            lblDailyBorrows.Text = $"Günlük Ödünç: {dailyBorrows}";
            lblDailyReturns.Text = $"Günlük İade: {dailyReturns}";
            lblOverdue.Text = $"Gecikmiş: {overdueCount}";
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                Validators.InputValidator.ShowError("Lütfen bir talep seçin.");
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells[0].Value);
            string statusText = dgvRequests.SelectedRows[0].Cells[4].Value.ToString();
            
            BorrowStatus currentStatus = BorrowStatus.Beklemede;
            switch (statusText)
            {
                case "Beklemede": currentStatus = BorrowStatus.Beklemede; break;
                case "Onaylandı": currentStatus = BorrowStatus.Onaylandı; break;
                case "Teslim Edildi": currentStatus = BorrowStatus.TeslimEdildi; break;
                case "İade Edildi": currentStatus = BorrowStatus.İadeEdildi; break;
                case "Gecikmiş": currentStatus = BorrowStatus.Gecikmiş; break;
                case "Reddedildi": currentStatus = BorrowStatus.Reddedildi; break;
            }

            if (currentStatus == BorrowStatus.Reddedildi || currentStatus == BorrowStatus.İadeEdildi)
            {
                Validators.InputValidator.ShowError("Bu talep tamamlanmış (Reddedildi veya İade Edildi). Artık güncellenemez.");
                return;
            }

            UpdateStatusForm updateForm = new UpdateStatusForm(requestId, currentStatus);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                LoadBorrowRequests();
                LoadDailySummary();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowRequests();
            LoadDailySummary();
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

