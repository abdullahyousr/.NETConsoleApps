using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementApp
{
    public static class Utilities
    {
        private static string directoryPath = @"D:\data\BookManagementApp";
        private static string fileName = "books.txt";

        public static void CheckForExistingBookFile()
        {
            string filePath = $"{directoryPath}\\{fileName}";

            // Check if the file already exists
            bool fileExists = File.Exists(filePath);

            if (fileExists)
            {
                Console.WriteLine("Book data file already exists.");
            }
            else
            {
                // If directory doesn't exist, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Directory created for storing book data.");
                    Console.ResetColor();
                }

                Console.WriteLine("Book data file does not exist yet. It will be created when saving data.");
            }
        }

        public static void SaveBooksToFile(List<Book> books)
        {
            string filePath = $"{directoryPath}\\{fileName}";

            // Using StringBuilder to concatenate all the book information into a single string.
            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                // Convert each book into a string representation.
                sb.Append($"Title:{book.Title};Author:{book.Author};Genre:{book.Genre};PublicationDate:{book.PublicationDate:yyyy-MM-dd}\n");
            }

            // Write the concatenated book data to the file.
            File.WriteAllText(filePath, sb.ToString());

            Console.WriteLine("Books saved to file successfully.");
        }

        public static void LoadBooksFromFile(List<Book> books)
        {
            string filePath = $"{directoryPath}\\{fileName}";

            // If the file doesn't exist, there's nothing to load
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No book data file found to load.");
                return;
            }

            // Clear existing books in memory
            books.Clear();

            // Reading all lines from the file
            string[] booksAsStrings = File.ReadAllLines(filePath);

            foreach (string bookAsString in booksAsStrings)
            {
                string[] parts = bookAsString.Split('|');
                    if (parts.Length == 4)
                    {
                        string title = parts[0];
                        string author = parts[1];
                        string genre = parts[2];
                        DateTime publicationDate = DateTime.Parse(parts[3]);

                        Book book = new Book(title, author, genre, publicationDate);
                        books.Add(book);
                    }
                }
            }
        
        public static void RegisterBook(List<Book> books)
        {
            Console.WriteLine("\nRegister a New Book:");

            // Collecting book details from the user
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Genre (e.g., Fiction, Mystery): ");
            string genre = Console.ReadLine()!;

            Console.Write("Enter Publication Date (yyyy-mm-dd): ");
            DateTime publicationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out publicationDate))
            {
                Console.Write("Invalid date format. Enter Publication Date (yyyy-mm-dd): ");
            }

            // Creating a new Book instance and adding it to the list
            Book newBook = new Book(title, author, genre, publicationDate);
            books.Add(newBook);

            Console.WriteLine("Book registered successfully!");
        }

        public static void ViewBooks(List<Book> books)
        {
            Console.WriteLine("\nList of Registered Books:");

            if (books.Count == 0)
            {
                Console.WriteLine("No books registered.");
            }
            else
            {
                foreach (var book in books)
                {
                    book.DisplayBookDetails(); // Display each book's details.
                }
            }
        }
    }
}