using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using LibraryManagementSystem.Database;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Validators;

namespace LibraryManagementSystem.Forms
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.Rows.Clear();
            string query = @"
                SELECT Id, FirstName, LastName, Email, SchoolNumber, Phone, Role, CreatedAt
                FROM Users
                ORDER BY CreatedAt DESC";

            using (var reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string roleText = "";
                    switch ((UserRole)reader.GetInt32(6))
                    {
                        case UserRole.Student:
                            roleText = "Öğrenci";
                            break;
                        case UserRole.Staff:
                            roleText = "Personel";
                            break;
                        case UserRole.Admin:
                            roleText = "Yönetici";
                            break;
                    }

                    dgvUsers.Rows.Add(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.IsDBNull(4) ? "" : reader.GetString(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        roleText,
                        reader.GetDateTime(7).ToString("dd.MM.yyyy")
                    );
                }
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddStaffForm addForm = new AddStaffForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                InputValidator.ShowError("Lütfen silmek için bir kullanıcı seçin.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
            string userRole = dgvUsers.SelectedRows[0].Cells[6].Value.ToString();

            if (userRole == "Yönetici")
            {
                InputValidator.ShowError("Yönetici kullanıcılar silinemez.");
                return;
            }

            if (InputValidator.ShowConfirmation("Bu kullanıcıyı silmek istediğinize emin misiniz?") == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM Users WHERE Id = @id";
                    DatabaseHelper.ExecuteNonQuery(deleteQuery, new SQLiteParameter("@id", userId));
                    InputValidator.ShowSuccess("Kullanıcı başarıyla silindi.");
                    LoadUsers();
                }
                catch (SQLiteException)
                {
                    InputValidator.ShowError("Uyarı: Bu kullanıcının geçmiş kiralama işlemleri olduğu için veritabanından başarıyla silinemez.");
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteUser.Enabled = dgvUsers.SelectedRows.Count > 0;
        }
    }

    public partial class AddStaffForm : Form
    {
        public AddStaffForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string phone = txtPhone.Text.Trim();

            if (!InputValidator.ValidateRequired(firstName, "Ad", out string error))
            {
                InputValidator.ShowError(error);
                return;
            }

            if (!InputValidator.ValidateRequired(lastName, "Soyad", out error))
            {
                InputValidator.ShowError(error);
                return;
            }

            if (!InputValidator.ValidateEmail(email, out error))
            {
                InputValidator.ShowError(error);
                return;
            }

            if (!InputValidator.ValidatePassword(password, out error))
            {
                InputValidator.ShowError(error);
                return;
            }

            // Check if email exists
            string checkEmail = "SELECT COUNT(*) FROM Users WHERE Email = @email";
            object result = DatabaseHelper.ExecuteScalar(checkEmail, new SQLiteParameter("@email", email));
            if (Convert.ToInt32(result) > 0)
            {
                InputValidator.ShowError("Bu e-posta adresi zaten kullanılıyor.");
                return;
            }

            // Hash password
            string hashedPassword = AuthService.HashPassword(password);
            string insertQuery = @"
                INSERT INTO Users (FirstName, LastName, Email, Password, Phone, Role)
                VALUES (@firstName, @lastName, @email, @password, @phone, 2)";

            DatabaseHelper.ExecuteNonQuery(insertQuery,
                new SQLiteParameter("@firstName", firstName),
                new SQLiteParameter("@lastName", lastName),
                new SQLiteParameter("@email", email),
                new SQLiteParameter("@password", hashedPassword),
                new SQLiteParameter("@phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : (object)phone));

            InputValidator.ShowSuccess("Personel başarıyla eklendi.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

