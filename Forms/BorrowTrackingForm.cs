using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class BorrowTrackingForm : Form
    {
        public BorrowTrackingForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadBorrowRequests();
        }

        private void LoadBorrowRequests()
        {
            dgvBorrows.Rows.Clear();
            BorrowService.CheckOverdueBooks(); // Check for overdue books first
            
            var requests = BorrowService.GetUserBorrowRequests(Services.AuthService.CurrentUser.Id);
            foreach (var request in requests)
            {
                dgvBorrows.Rows.Add(
                    request.Id,
                    request.BookTitle,
                    request.RequestDate.ToString("dd.MM.yyyy"),
                    request.ApprovedDate?.ToString("dd.MM.yyyy") ?? "-",
                    request.DeliveryDate?.ToString("dd.MM.yyyy") ?? "-",
                    request.DueDate?.ToString("dd.MM.yyyy") ?? "-",
                    request.ReturnDate?.ToString("dd.MM.yyyy") ?? "-",
                    request.StatusText
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBorrowRequests();
        }
    }
}

