using System;

namespace LibraryManagementSystem.Models
{
    public enum BorrowStatus
    {
        Beklemede = 1,
        Onaylandı = 2,
        TeslimEdildi = 3,
        İadeEdildi = 4,
        Gecikmiş = 5,
        Reddedildi = 6
    }

    public class BorrowRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DueDate { get; set; }
        public BorrowStatus Status { get; set; }
        public string StatusText => GetStatusText();
        public string Notes { get; set; }

        private string GetStatusText()
        {
            switch (Status)
            {
                case BorrowStatus.Beklemede:
                    return "Beklemede";
                case BorrowStatus.Onaylandı:
                    return "Onaylandı";
                case BorrowStatus.TeslimEdildi:
                    return "Teslim Edildi";
                case BorrowStatus.İadeEdildi:
                    return "İade Edildi";
                case BorrowStatus.Gecikmiş:
                    return "Gecikmiş";
                case BorrowStatus.Reddedildi:
                    return "Reddedildi";
                default:
                    return "Bilinmiyor";
            }
        }
    }
}

