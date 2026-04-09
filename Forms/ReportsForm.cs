using System;
using System.Windows.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnRefresh, "Verileri güncellemek için tıklayın.");
            
            LoadReports();
            
            this.Activated += (s, e) => LoadReports();
        }

        private void LoadReports()
        {
            DateTime today = DateTime.Now;
            
            // Daily stats
            int dailyBorrows = ReportService.GetDailyBorrowCount(today);
            int dailyReturns = ReportService.GetDailyReturnCount(today);
            lblDailyBorrows.Text = $"Günlük Ödünç: {dailyBorrows}";
            lblDailyReturns.Text = $"Günlük İade: {dailyReturns}";

            // Weekly stats
            DateTime weekStart = today.AddDays(-(int)today.DayOfWeek);
            int weeklyBorrows = ReportService.GetWeeklyBorrowCount(weekStart);
            lblWeeklyBorrows.Text = $"Haftalık Ödünç: {weeklyBorrows}";

            // Monthly stats
            int monthlyBorrows = ReportService.GetMonthlyBorrowCount(today.Year, today.Month);
            lblMonthlyBorrows.Text = $"Aylık Ödünç: {monthlyBorrows}";

            // Overdue
            int overdueCount = ReportService.GetOverdueCount();
            lblOverdue.Text = $"Gecikmiş Kitaplar: {overdueCount}";

            // Most borrowed books
            LoadMostBorrowedBooks();
        }

        private void LoadMostBorrowedBooks()
        {
            dgvMostBorrowed.Rows.Clear();
            var mostBorrowed = ReportService.GetMostBorrowedBooks(10);
            foreach (var book in mostBorrowed)
            {
                dgvMostBorrowed.Rows.Add(
                    book["Title"],
                    book["Author"],
                    book["BorrowCount"]
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }
    }
}

