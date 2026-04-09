using System;
using System.Data.SQLite;
using System.IO;

namespace LibraryManagementSystem.Database
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=library.db;Version=3;Foreign Keys=True;";

        public static void InitializeDatabase()
        {
            if (!File.Exists("library.db"))
            {
                SQLiteConnection.CreateFile("library.db");
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create Users table
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        SchoolNumber TEXT,
                        Phone TEXT,
                        Role INTEGER NOT NULL DEFAULT 1,
                        CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                    )";

                // Create Categories table
                string createCategoriesTable = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE,
                        Description TEXT
                    )";

                // Create Books table
                string createBooksTable = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        ISBN TEXT,
                        CategoryId INTEGER,
                        PublicationYear INTEGER,
                        Publisher TEXT,
                        Description TEXT,
                        Stock INTEGER NOT NULL DEFAULT 0,
                        ShelfLocation TEXT,
                        CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                    )";

                // Create BorrowRequests table
                string createBorrowRequestsTable = @"
                    CREATE TABLE IF NOT EXISTS BorrowRequests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        BookId INTEGER NOT NULL,
                        RequestDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        ApprovedDate DATETIME,
                        DeliveryDate DATETIME,
                        ReturnDate DATETIME,
                        DueDate DATETIME,
                        Status INTEGER NOT NULL DEFAULT 1,
                        Notes TEXT,
                        FOREIGN KEY (UserId) REFERENCES Users(Id),
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    )";

                ExecuteNonQuery(createUsersTable);
                ExecuteNonQuery(createCategoriesTable);
                ExecuteNonQuery(createBooksTable);
                ExecuteNonQuery(createBorrowRequestsTable);

                // Insert default admin user if not exists
                string checkAdmin = "SELECT COUNT(*) FROM Users WHERE Role = 3";
                object adminCount = ExecuteScalar(checkAdmin);
                if (Convert.ToInt32(adminCount) == 0)
                {
                    string insertAdmin = @"
                        INSERT INTO Users (FirstName, LastName, Email, Password, Role)
                        VALUES ('Admin', 'User', 'admin@library.com', @password, 3)";
                    
                    using (var sha256 = System.Security.Cryptography.SHA256.Create())
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes("Admin123");
                        byte[] hash = sha256.ComputeHash(bytes);
                        string hashedPassword = Convert.ToBase64String(hash);
                        
                        ExecuteNonQuery(insertAdmin, new SQLiteParameter("@password", hashedPassword));
                    }
                }

                // Insert default categories if not exists
                string checkCategories = "SELECT COUNT(*) FROM Categories";
                object categoryCount = ExecuteScalar(checkCategories);
                if (Convert.ToInt32(categoryCount) == 0)
                {
                    ExecuteNonQuery("INSERT INTO Categories (Name, Description) VALUES ('Roman', 'Roman kategorisi')");
                    ExecuteNonQuery("INSERT INTO Categories (Name, Description) VALUES ('Bilim', 'Bilim kitapları')");
                    ExecuteNonQuery("INSERT INTO Categories (Name, Description) VALUES ('Tarih', 'Tarih kitapları')");
                    ExecuteNonQuery("INSERT INTO Categories (Name, Description) VALUES ('Edebiyat', 'Edebiyat kitapları')");
                }

                connection.Close();
            }

            // Seed initial data
            SeedData();
        }

        private static void SeedData()
        {
            // Check if we need to seed books
            string checkBooks = "SELECT COUNT(*) FROM Books";
            object bookCount = ExecuteScalar(checkBooks);
            
            if (Convert.ToInt32(bookCount) == 0)
            {
                // Add sample books
                string[] books = new string[] 
                {
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Sefiller', 'Victor Hugo', '9789750000001', 1, 1862, 'İş Bankası Yayınları', 'Jan Valjean hikayesi', 5, 'A-1')",
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Suç ve Ceza', 'Fyodor Dostoyevski', '9789750000002', 1, 1866, 'Can Yayınları', 'Raskolnikov un iç çelişkileri', 3, 'A-2')",
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Nutuk', 'Mustafa Kemal Atatürk', '9789750000003', 3, 1927, 'Yapı Kredi Yayınları', 'Türkiye Cumhuriyetinin kuruluşu', 10, 'B-1')",
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Evrenin Kısa Tarihi', 'Stephen Hawking', '9789750000004', 2, 1988, 'Alfa Yayıncılık', 'Modern kozmoloji', 4, 'C-1')",
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Kürk Mantolu Madonna', 'Sabahattin Ali', '9789750000005', 4, 1943, 'Yapı Kredi Yayınları', 'Bir aşk hikayesi', 8, 'A-3')",
                    "INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, Publisher, Description, Stock, ShelfLocation) VALUES ('Beylinin Kedisi', 'Halid Ziya', '9789750000006', 4, 1900, 'Özgür Yayınları', 'Edebiyat klasigi', 2, 'A-4')"
                };

                foreach (var query in books)
                {
                    ExecuteNonQuery(query);
                }
            }

            // Check if we need to seed a sample student
            string checkStudent = "SELECT COUNT(*) FROM Users WHERE Role = 1";
            object studentCount = ExecuteScalar(checkStudent);

            if (Convert.ToInt32(studentCount) == 0)
            {
                 string insertStudent = @"
                        INSERT INTO Users (FirstName, LastName, Email, Password, Role, SchoolNumber)
                        VALUES ('Ahmet', 'Yılmaz', 'ogrenci@okul.com', @password, 1, '2023001')";
                    
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes("Ogrenci123"); // Password: Ogrenci123
                    byte[] hash = sha256.ComputeHash(bytes);
                    string hashedPassword = Convert.ToBase64String(hash);
                    
                    ExecuteNonQuery(insertStudent, new SQLiteParameter("@password", hashedPassword));
                }
            }
        }

        public static SQLiteDataReader ExecuteReader(string query, params SQLiteParameter[] parameters)
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public static int ExecuteNonQuery(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteScalar();
                }
            }
        }
    }
}

