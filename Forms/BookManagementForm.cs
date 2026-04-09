using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Forms
{
    public partial class BookManagementForm : Form
    {
        public BookManagementForm()
        {
            InitializeComponent();
            LibraryManagementSystem.Utils.ThemeManager.ApplyTheme(this);
            LoadCategories();
            LoadBooks();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Kategori Seçin");
            var categories = BookService.GetAllCategories();
            foreach (var category in categories)
            {
                cmbCategory.Items.Add(category);
            }
            if (cmbCategory.Items.Count > 0)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            var book = new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                ISBN = txtISBN.Text.Trim(),
                CategoryId = cmbCategory.SelectedIndex > 0 ? ((Category)cmbCategory.SelectedItem).Id : 0,
                PublicationYear = Convert.ToInt32(txtYear.Text),
                Publisher = txtPublisher.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Stock = Convert.ToInt32(txtStock.Text),
                ShelfLocation = txtShelfLocation.Text.Trim()
            };

            if (BookService.AddBook(book))
            {
                Validators.InputValidator.ShowSuccess("Kitap başarıyla eklendi.");
                ClearInputs();
                LoadBooks();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                Validators.InputValidator.ShowError("Lütfen güncellemek için bir kitap seçin.");
                return;
            }

            if (!ValidateInputs())
                return;

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
            var book = new Book
            {
                Id = bookId,
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                ISBN = txtISBN.Text.Trim(),
                CategoryId = cmbCategory.SelectedIndex > 0 ? ((Category)cmbCategory.SelectedItem).Id : 0,
                PublicationYear = Convert.ToInt32(txtYear.Text),
                Publisher = txtPublisher.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Stock = Convert.ToInt32(txtStock.Text),
                ShelfLocation = txtShelfLocation.Text.Trim()
            };

            if (BookService.UpdateBook(book))
            {
                Validators.InputValidator.ShowSuccess("Kitap başarıyla güncellendi.");
                ClearInputs();
                LoadBooks();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                Validators.InputValidator.ShowError("Lütfen silmek için bir kitap seçin.");
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
            if (Validators.InputValidator.ShowConfirmation("Bu kitabı silmek istediğinize emin misiniz?") == DialogResult.Yes)
            {
                if (BookService.DeleteBook(bookId))
                {
                    Validators.InputValidator.ShowSuccess("Kitap başarıyla silindi.");
                    LoadBooks();
                }
                else
                {
                    Validators.InputValidator.ShowError("Bu kitap aktif ödünç talepleri olduğu için silinemez.");
                }
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells[0].Value);
                var book = BookService.GetBookById(bookId);
                if (book != null)
                {
                    txtTitle.Text = book.Title;
                    txtAuthor.Text = book.Author;
                    txtISBN.Text = book.ISBN ?? "";
                    txtYear.Text = book.PublicationYear.ToString();
                    txtPublisher.Text = book.Publisher ?? "";
                    txtDescription.Text = book.Description ?? "";
                    txtStock.Text = book.Stock.ToString();
                    txtShelfLocation.Text = book.ShelfLocation ?? "";
                    
                    // Set category
                    for (int i = 1; i < cmbCategory.Items.Count; i++)
                    {
                        if (cmbCategory.Items[i] is Category cat && cat.Id == book.CategoryId)
                        {
                            cmbCategory.SelectedIndex = i;
                            break;
                        }
                    }
                    if (cmbCategory.SelectedIndex == -1)
                        cmbCategory.SelectedIndex = 0;
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                Validators.InputValidator.ShowError("Başlık alanı boş bırakılamaz.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                Validators.InputValidator.ShowError("Yazar alanı boş bırakılamaz.");
                return false;
            }

            if (!int.TryParse(txtYear.Text, out int year) || year < 1000 || year > DateTime.Now.Year)
            {
                Validators.InputValidator.ShowError("Geçerli bir yayın yılı giriniz.");
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                Validators.InputValidator.ShowError("Stok 0 veya daha büyük bir sayı olmalıdır.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtYear.Clear();
            txtPublisher.Clear();
            txtDescription.Clear();
            txtStock.Clear();
            txtShelfLocation.Clear();
            cmbCategory.SelectedIndex = 0;
            dgvBooks.ClearSelection();
        }
    }
}

