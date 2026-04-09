using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LibraryManagementSystem.Database;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Validators;

namespace LibraryManagementSystem.Services
{
    public class BorrowService
    {
        public static bool CreateBorrowRequest(int userId, int bookId)
        {
            // Check if book is available
            string checkStock = "SELECT Stock FROM Books WHERE Id = @bookId";
            object stockResult = DatabaseHelper.ExecuteScalar(checkStock, new SQLiteParameter("@bookId", bookId));
            
            if (stockResult == null)
            {
                Validators.InputValidator.ShowError("Kitap bulunamadı.");
                return false; // Book not found
            }

            int stock = Convert.ToInt32(stockResult);
            if (stock <= 0)
            {
                Validators.InputValidator.ShowError("Bu kitap şu anda ödünç verilemez. Stokta bulunmamaktadır.");
                return false; // No stock available
            }

            // Check if user already has a pending request for this book
            string checkExisting = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE UserId = @userId AND BookId = @bookId AND Status = 1";

            object existingResult = DatabaseHelper.ExecuteScalar(checkExisting,
                new SQLiteParameter("@userId", userId),
                new SQLiteParameter("@bookId", bookId));

            if (Convert.ToInt32(existingResult) > 0)
            {
                Validators.InputValidator.ShowError("Bu kitap için zaten bekleyen bir talebiniz var.");
                return false; // Already has pending request
            }

            // Create borrow request
            string query = @"
                INSERT INTO BorrowRequests (UserId, BookId, Status)
                VALUES (@userId, @bookId, 1)";

            DatabaseHelper.ExecuteNonQuery(query,
                new SQLiteParameter("@userId", userId),
                new SQLiteParameter("@bookId", bookId));

            return true;
        }

        public static List<BorrowRequest> GetUserBorrowRequests(int userId)
        {
            var requests = new List<BorrowRequest>();
            string query = @"
                SELECT br.Id, br.UserId, u.FirstName || ' ' || u.LastName, br.BookId, 
                       b.Title, br.RequestDate, br.ApprovedDate, br.DeliveryDate, 
                       br.ReturnDate, br.DueDate, br.Status, br.Notes
                FROM BorrowRequests br
                INNER JOIN Users u ON br.UserId = u.Id
                INNER JOIN Books b ON br.BookId = b.Id
                WHERE br.UserId = @userId
                ORDER BY br.RequestDate DESC";

            using (var reader = DatabaseHelper.ExecuteReader(query, new SQLiteParameter("@userId", userId)))
            {
                while (reader.Read())
                {
                    requests.Add(new BorrowRequest
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        UserName = reader.GetString(2),
                        BookId = reader.GetInt32(3),
                        BookTitle = reader.GetString(4),
                        RequestDate = reader.GetDateTime(5),
                        ApprovedDate = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                        DeliveryDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                        ReturnDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                        DueDate = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9),
                        Status = (BorrowStatus)reader.GetInt32(10),
                        Notes = reader.IsDBNull(11) ? null : reader.GetString(11)
                    });
                }
            }

            return requests;
        }

        public static List<BorrowRequest> GetAllBorrowRequests()
        {
            var requests = new List<BorrowRequest>();
            string query = @"
                SELECT br.Id, br.UserId, u.FirstName || ' ' || u.LastName, br.BookId, 
                       b.Title, br.RequestDate, br.ApprovedDate, br.DeliveryDate, 
                       br.ReturnDate, br.DueDate, br.Status, br.Notes
                FROM BorrowRequests br
                INNER JOIN Users u ON br.UserId = u.Id
                INNER JOIN Books b ON br.BookId = b.Id
                ORDER BY br.RequestDate DESC";

            using (var reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    requests.Add(new BorrowRequest
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        UserName = reader.GetString(2),
                        BookId = reader.GetInt32(3),
                        BookTitle = reader.GetString(4),
                        RequestDate = reader.GetDateTime(5),
                        ApprovedDate = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                        DeliveryDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                        ReturnDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                        DueDate = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9),
                        Status = (BorrowStatus)reader.GetInt32(10),
                        Notes = reader.IsDBNull(11) ? null : reader.GetString(11)
                    });
                }
            }

            return requests;
        }

        public static bool UpdateBorrowStatus(int requestId, BorrowStatus newStatus, string notes = null)
        {
            string getExisting = "SELECT Status, BookId FROM BorrowRequests WHERE Id = @id";
            BorrowStatus currentStatus;
            int bookIdToUpdate;
            using (var reader = DatabaseHelper.ExecuteReader(getExisting, new SQLiteParameter("@id", requestId)))
            {
                if (!reader.Read()) return false;
                currentStatus = (BorrowStatus)reader.GetInt32(0);
                bookIdToUpdate = reader.GetInt32(1);
            }

            if (currentStatus == newStatus)
            {
                string updateNotes = "UPDATE BorrowRequests SET Notes = @notes WHERE Id = @id";
                DatabaseHelper.ExecuteNonQuery(updateNotes, 
                    new SQLiteParameter("@notes", (object)notes ?? DBNull.Value),
                    new SQLiteParameter("@id", requestId));
                return true;
            }

            string query = "";
            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            switch (newStatus)
            {
                case BorrowStatus.Onaylandı:
                    query = @"
                        UPDATE BorrowRequests 
                        SET Status = @status, ApprovedDate = @date, Notes = @notes
                        WHERE Id = @id";
                    parameters.Add(new SQLiteParameter("@status", (int)newStatus));
                    parameters.Add(new SQLiteParameter("@date", DateTime.Now));
                    parameters.Add(new SQLiteParameter("@notes", (object)notes ?? DBNull.Value));
                    parameters.Add(new SQLiteParameter("@id", requestId));
                    break;

                case BorrowStatus.TeslimEdildi:
                    if (currentStatus != BorrowStatus.TeslimEdildi && currentStatus != BorrowStatus.Gecikmiş)
                    {
                        string updateStock = "UPDATE Books SET Stock = Stock - 1 WHERE Id = @bookId AND Stock > 0";
                        int rowsAffected = DatabaseHelper.ExecuteNonQuery(updateStock, new SQLiteParameter("@bookId", bookIdToUpdate));
                        if (rowsAffected == 0)
                        {
                            Validators.InputValidator.ShowError("Stok yetersiz! Kitap teslim edilemez veya başkası tarafından alındı.");
                            return false;
                        }
                    }

                    query = @"
                        UPDATE BorrowRequests 
                        SET Status = @status, DeliveryDate = @date, DueDate = @dueDate, Notes = @notes
                        WHERE Id = @id";
                    parameters.Add(new SQLiteParameter("@status", (int)newStatus));
                    parameters.Add(new SQLiteParameter("@date", DateTime.Now));
                    parameters.Add(new SQLiteParameter("@dueDate", DateTime.Now.AddDays(14)));
                    parameters.Add(new SQLiteParameter("@notes", (object)notes ?? DBNull.Value));
                    parameters.Add(new SQLiteParameter("@id", requestId));
                    break;

                case BorrowStatus.İadeEdildi:
                    if (currentStatus == BorrowStatus.TeslimEdildi || currentStatus == BorrowStatus.Gecikmiş)
                    {
                        string updateStockReturn = "UPDATE Books SET Stock = Stock + 1 WHERE Id = @bookId";
                        DatabaseHelper.ExecuteNonQuery(updateStockReturn, new SQLiteParameter("@bookId", bookIdToUpdate));
                    }

                    query = @"
                        UPDATE BorrowRequests 
                        SET Status = @status, ReturnDate = @date, Notes = @notes
                        WHERE Id = @id";
                    parameters.Add(new SQLiteParameter("@status", (int)newStatus));
                    parameters.Add(new SQLiteParameter("@date", DateTime.Now));
                    parameters.Add(new SQLiteParameter("@notes", (object)notes ?? DBNull.Value));
                    parameters.Add(new SQLiteParameter("@id", requestId));
                    break;

                case BorrowStatus.Reddedildi:
                default:
                    query = @"
                        UPDATE BorrowRequests 
                        SET Status = @status, Notes = @notes
                        WHERE Id = @id";
                    parameters.Add(new SQLiteParameter("@status", (int)newStatus));
                    parameters.Add(new SQLiteParameter("@notes", (object)notes ?? DBNull.Value));
                    parameters.Add(new SQLiteParameter("@id", requestId));
                    break;
            }

            DatabaseHelper.ExecuteNonQuery(query, parameters.ToArray());
            return true;
        }

        public static void CheckOverdueBooks()
        {
            string query = @"
                UPDATE BorrowRequests 
                SET Status = 5
                WHERE Status = 3 AND DueDate < @now AND ReturnDate IS NULL";

            DatabaseHelper.ExecuteNonQuery(query, new SQLiteParameter("@now", DateTime.Now));
        }
    }
}

