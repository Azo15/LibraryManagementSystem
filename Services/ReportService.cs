using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LibraryManagementSystem.Database;

namespace LibraryManagementSystem.Services
{
    public class ReportService
    {
        public static int GetDailyBorrowCount(DateTime date)
        {
            string query = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE DATE(DeliveryDate) = DATE(@date) AND Status >= 3";

            object result = DatabaseHelper.ExecuteScalar(query, new SQLiteParameter("@date", date));
            return Convert.ToInt32(result);
        }

        public static int GetWeeklyBorrowCount(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);
            string query = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE DeliveryDate >= @startDate AND DeliveryDate < @endDate AND Status >= 3";

            object result = DatabaseHelper.ExecuteScalar(query,
                new SQLiteParameter("@startDate", startDate),
                new SQLiteParameter("@endDate", endDate));
            return Convert.ToInt32(result);
        }

        public static int GetMonthlyBorrowCount(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1);
            string query = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE DeliveryDate >= @startDate AND DeliveryDate < @endDate AND Status >= 3";

            object result = DatabaseHelper.ExecuteScalar(query,
                new SQLiteParameter("@startDate", startDate),
                new SQLiteParameter("@endDate", endDate));
            return Convert.ToInt32(result);
        }

        public static int GetDailyReturnCount(DateTime date)
        {
            string query = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE DATE(ReturnDate) = DATE(@date) AND Status = 4";

            object result = DatabaseHelper.ExecuteScalar(query, new SQLiteParameter("@date", date));
            return Convert.ToInt32(result);
        }

        public static int GetOverdueCount()
        {
            string query = @"
                SELECT COUNT(*) FROM BorrowRequests 
                WHERE Status = 5 OR (Status = 3 AND DueDate < @now AND ReturnDate IS NULL)";

            object result = DatabaseHelper.ExecuteScalar(query, new SQLiteParameter("@now", DateTime.Now));
            return Convert.ToInt32(result);
        }

        public static List<Dictionary<string, object>> GetMostBorrowedBooks(int limit = 10)
        {
            var results = new List<Dictionary<string, object>>();
            string query = @"
                SELECT b.Title, b.Author, COUNT(br.Id) as BorrowCount
                FROM Books b
                INNER JOIN BorrowRequests br ON b.Id = br.BookId
                WHERE br.Status >= 3
                GROUP BY b.Id, b.Title, b.Author
                ORDER BY BorrowCount DESC
                LIMIT @limit";

            using (var reader = DatabaseHelper.ExecuteReader(query, new SQLiteParameter("@limit", limit)))
            {
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>
                    {
                        ["Title"] = reader.GetString(0),
                        ["Author"] = reader.GetString(1),
                        ["BorrowCount"] = reader.GetInt32(2)
                    };
                    results.Add(row);
                }
            }

            return results;
        }

        public static Dictionary<string, int> GetBorrowStatsByCategory()
        {
            var stats = new Dictionary<string, int>();
            string query = @"
                SELECT c.Name, COUNT(br.Id) as Count
                FROM Categories c
                LEFT JOIN Books b ON c.Id = b.CategoryId
                LEFT JOIN BorrowRequests br ON b.Id = br.BookId AND br.Status >= 3
                GROUP BY c.Id, c.Name
                ORDER BY Count DESC";

            using (var reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    stats[reader.GetString(0)] = reader.GetInt32(1);
                }
            }

            return stats;
        }
    }
}

