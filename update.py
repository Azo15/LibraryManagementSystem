import sys
import re

file_path = 'c:/Users/ismai/Downloads/Grup_7_kaynakKodlar/Grup_7_kaynakKodlar/Gorsel-Programlama-KYS-Projesi/LibraryManagementSystem/Services/BorrowService.cs'
with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

start_pattern = r'public static bool UpdateBorrowStatus\(int requestId, BorrowStatus newStatus, string notes \= null\).*?return true;\s+\}'

replacement = """public static bool UpdateBorrowStatus(int requestId, BorrowStatus newStatus, string notes = null)
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
        }"""

new_content = re.sub(start_pattern, replacement, content, flags=re.DOTALL)

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(new_content)
print('Update successful')
