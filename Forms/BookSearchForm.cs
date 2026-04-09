using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class BookSearchForm : Form
    {
        public Book SelectedBook { get; private set; }

        public BookSearchForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadCategories();
            LoadBooks();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Tümü");
            var categories = BookService.GetAllCategories();
            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category.Name);
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();
            var books = BookService.GetAllBooks();
            foreach (var book in books)
            {
                dgvBooks.Rows.Add(
                    book.Id,
                    book.Title,
                    book.Author,
                    book.CategoryName,
                    book.PublicationYear,
                    book.Stock,
                    book.ShelfLocation
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString() == "Tümü" ? null : cmbCategory.SelectedItem?.ToString();
            string author = txtAuthor.Text.Trim();
            int? year = null;
            
            if (!string.IsNullOrWhiteSpace(txtYear.Text))
            {
                if (int.TryParse(txtYear.Text, out int yearValue))
                {
                    year = yearValue;
                }
            }

            var books = BookService.SearchBooks(searchTerm, category, author, year);
            dgvBooks.Rows.Clear();
            foreach (var book in books)
            {
                dgvBooks.Rows.Add(
                    book.Id,
                    book.Title,
                    book.Author,
                    book.CategoryName,
                    book.PublicationYear,
                    book.Stock,
                    book.ShelfLocation
                );
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                Validators.InputValidator.ShowError("Lütfen bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
            SelectedBook = BookService.GetBookById(bookId);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e);
            }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                Validators.InputValidator.ShowError("Lütfen bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
            var book = BookService.GetBookById(bookId);
            if (book != null)
            {
                string details = $"Başlık: {book.Title}\n" +
                               $"Yazar: {book.Author}\n" +
                               $"ISBN: {book.ISBN ?? "Yok"}\n" +
                               $"Kategori: {book.CategoryName}\n" +
                               $"Yayın Yılı: {book.PublicationYear}\n" +
                               $"Yayınevi: {book.Publisher ?? "Yok"}\n" +
                               $"Açıklama: {book.Description ?? "Yok"}\n" +
                               $"Stok: {book.Stock}\n" +
                               $"Raf Konumu: {book.ShelfLocation ?? "Yok"}";
                
                MessageBox.Show(details, "Kitap Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

