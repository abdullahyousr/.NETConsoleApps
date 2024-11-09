using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Library
    {
        private Book[] books = new Book[100];
        private int currentBookCount = 0; 
        private int currentBorrowedBookCount = 0; 
        private Book[] BorrowedBooks = new Book[50];

        public void Display()
        {
            for (int i = 0; i < currentBookCount; i++)
            {
                Console.WriteLine($"{books[i].Title}, {books[i].Author}, {books[i].Year}");
            }
        }
        public void Add(Book book)
        {
            if(currentBookCount >= books.Length)
            {
                Console.WriteLine("Library is full, can not add a book.");
            }
            else
            {
                books[currentBookCount] = book;
                currentBookCount++;
                Console.WriteLine("Book added successfully");
            }
        }

        public void Remove(Book book)
        {
            int index = Array.IndexOf(books,book);

            books[index] = null!;
            currentBookCount--;
            Console.WriteLine("Book Removed");
        }
        public void Borrow(Book book)
        {
            if (currentBorrowedBookCount >= BorrowedBooks.Length)
            {
                Console.WriteLine("Sorry, can not borrow a book.");
            }
            else
            {
                books[currentBorrowedBookCount] = book;
                currentBorrowedBookCount++;
                Console.WriteLine("Book Borrowed successfully");
            }
        }

    }
}
