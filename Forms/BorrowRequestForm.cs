using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class BorrowRequestForm : Form
    {
        public BorrowRequestForm()
        {
            InitializeComponent();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            BookSearchForm searchForm = new BookSearchForm();
            if (searchForm.ShowDialog() == DialogResult.OK && searchForm.SelectedBook != null)
            {
                var book = searchForm.SelectedBook;
                txtBookId.Text = book.Id.ToString();
                txtBookTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtStock.Text = book.Stock.ToString();
                txtShelfLocation.Text = book.ShelfLocation ?? "Yok";
            }
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId.Text))
            {
                Validators.InputValidator.ShowError("Lütfen bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(txtBookId.Text);
            int userId = Services.AuthService.CurrentUser.Id;

            if (BorrowService.CreateBorrowRequest(userId, bookId))
            {
                Validators.InputValidator.ShowSuccess("Ödünç talebi başarıyla oluşturuldu.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

