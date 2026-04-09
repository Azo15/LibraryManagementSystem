using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LibraryManagementSystem.Database;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            string query = @"
                SELECT b.Id, b.Title, b.Author, b.ISBN, b.CategoryId, c.Name, 
                       b.PublicationYear, b.Publisher, b.Description, b.Stock, 
                       b.ShelfLocation, b.CreatedAt
                FROM Books b
                LEFT JOIN Categories c ON b.CategoryId = c.Id
                ORDER BY b.Title";

            using (var reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        ISBN = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        CategoryName = reader.IsDBNull(5) ? "Kategori Yok" : reader.GetString(5),
                        PublicationYear = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        Publisher = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Description = reader.IsDBNull(8) ? null : reader.GetString(8),
                        Stock = reader.GetInt32(9),
                        ShelfLocation = reader.IsDBNull(10) ? null : reader.GetString(10),
                        CreatedAt = reader.GetDateTime(11)
                    });
                }
            }

            return books;
        }

        public static List<Book> SearchBooks(string searchTerm, string category, string author, int? year)
        {
            var books = new List<Book>();
            string query = @"
                SELECT b.Id, b.Title, b.Author, b.ISBN, b.CategoryId, c.Name, 
                       b.PublicationYear, b.Publisher, b.Description, b.Stock, 
                       b.ShelfLocation, b.CreatedAt
                FROM Books b
                LEFT JOIN Categories c ON b.CategoryId = c.Id
                WHERE 1=1";

            var parameters = new List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " AND (b.Title LIKE @searchTerm OR b.Author LIKE @searchTerm OR b.ISBN LIKE @searchTerm)";
                parameters.Add(new SQLiteParameter("@searchTerm", $"%{searchTerm}%"));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query += " AND c.Name = @category";
                parameters.Add(new SQLiteParameter("@category", category));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query += " AND b.Author LIKE @author";
                parameters.Add(new SQLiteParameter("@author", $"%{author}%"));
            }

            if (year.HasValue)
            {
                query += " AND b.PublicationYear = @year";
                parameters.Add(new SQLiteParameter("@year", year.Value));
            }

            query += " ORDER BY b.Title";

            using (var reader = DatabaseHelper.ExecuteReader(query, parameters.ToArray()))
            {
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        ISBN = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        CategoryName = reader.IsDBNull(5) ? "Kategori Yok" : reader.GetString(5),
                        PublicationYear = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        Publisher = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Description = reader.IsDBNull(8) ? null : reader.GetString(8),
                        Stock = reader.GetInt32(9),
                        ShelfLocation = reader.IsDBNull(10) ? null : reader.GetString(10),
                        CreatedAt = reader.GetDateTime(11)
                    });
                }
            }

            return books;
        }

        public static Book GetBookById(int bookId)
        {
            string query = @"
                SELECT b.Id, b.Title, b.Author, b.ISBN, b.CategoryId, c.Name, 
                       b.PublicationYear, b.Publisher, b.Description, b.Stock, 
                       b.ShelfLocation, b.CreatedAt
                FROM Books b
                LEFT JOIN Categories c ON b.CategoryId = c.Id
                WHERE b.Id = @id";

            using (var reader = DatabaseHelper.ExecuteReader(query, new SQLiteParameter("@id", bookId)))
            {
                if (reader.Read())
                {
                    return new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        ISBN = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        CategoryName = reader.IsDBNull(5) ? "Kategori Yok" : reader.GetString(5),
                        PublicationYear = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        Publisher = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Description = reader.IsDBNull(8) ? null : reader.GetString(8),
                        Stock = reader.GetInt32(9),
                        ShelfLocation = reader.IsDBNull(10) ? null : reader.GetString(10),
                        CreatedAt = reader.GetDateTime(11)
                    };
                }
            }

            return null;
        }

        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            string query = "SELECT Id, Name, Description FROM Categories ORDER BY Name";

            using (var reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
            }

            return categories;
        }

        public static bool AddBook(Book book)
        {
            string query = @"
                INSERT INTO Books (Title, Author, ISBN, CategoryId, PublicationYear, 
                                 Publisher, Description, Stock, ShelfLocation)
                VALUES (@title, @author, @isbn, @categoryId, @year, @publisher, 
                       @description, @stock, @shelf)";

            DatabaseHelper.ExecuteNonQuery(query,
                new SQLiteParameter("@title", book.Title),
                new SQLiteParameter("@author", book.Author),
                new SQLiteParameter("@isbn", (object)book.ISBN ?? DBNull.Value),
                new SQLiteParameter("@categoryId", book.CategoryId > 0 ? (object)book.CategoryId : DBNull.Value),
                new SQLiteParameter("@year", book.PublicationYear),
                new SQLiteParameter("@publisher", (object)book.Publisher ?? DBNull.Value),
                new SQLiteParameter("@description", (object)book.Description ?? DBNull.Value),
                new SQLiteParameter("@stock", book.Stock),
                new SQLiteParameter("@shelf", (object)book.ShelfLocation ?? DBNull.Value));

            return true;
        }

        public static bool UpdateBook(Book book)
        {
            string query = @"
                UPDATE Books 
                SET Title = @title, Author = @author, ISBN = @isbn, CategoryId = @categoryId,
                    PublicationYear = @year, Publisher = @publisher, Description = @description,
                    Stock = @stock, ShelfLocation = @shelf
                WHERE Id = @id";

            DatabaseHelper.ExecuteNonQuery(query,
                new SQLiteParameter("@id", book.Id),
                new SQLiteParameter("@title", book.Title),
                new SQLiteParameter("@author", book.Author),
                new SQLiteParameter("@isbn", (object)book.ISBN ?? DBNull.Value),
                new SQLiteParameter("@categoryId", book.CategoryId > 0 ? (object)book.CategoryId : DBNull.Value),
                new SQLiteParameter("@year", book.PublicationYear),
                new SQLiteParameter("@publisher", (object)book.Publisher ?? DBNull.Value),
                new SQLiteParameter("@description", (object)book.Description ?? DBNull.Value),
                new SQLiteParameter("@stock", book.Stock),
                new SQLiteParameter("@shelf", (object)book.ShelfLocation ?? DBNull.Value));

            return true;
        }

        public static bool DeleteBook(int bookId)
        {
            // Check if book has ANY borrow requests (to prevent orphaned records)
            string checkBorrows = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE BookId = @bookId";

            object result = DatabaseHelper.ExecuteScalar(checkBorrows, new SQLiteParameter("@bookId", bookId));
            if (Convert.ToInt32(result) > 0)
            {
                return false; // Cannot delete book with active borrows
            }

            string query = "DELETE FROM Books WHERE Id = @id";
            DatabaseHelper.ExecuteNonQuery(query, new SQLiteParameter("@id", bookId));
            return true;
        }
    }
}

