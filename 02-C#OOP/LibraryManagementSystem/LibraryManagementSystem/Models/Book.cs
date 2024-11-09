using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Book otherBook)
            {
                return Title == otherBook.Title &&
                       Author == otherBook.Author &&
                       Year == otherBook.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Year);
        }
    }
}
