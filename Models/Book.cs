using System;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ShelfLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

