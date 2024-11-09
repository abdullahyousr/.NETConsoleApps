using LibraryManagementSystem.Models;

Library library = new();
Console.WriteLine("Welcome to the library system");
Console.WriteLine("Are you Librarian or regular user (L/R)");

string userChoise = Console.ReadLine()!.ToUpper();
char userType = userChoise[0];

if (userType == 'L')
{
    // Welcome
    Console.Write("Welcome librarian, Enter your name: ");
    string librarianName = Console.ReadLine()!;
    Librarian librarian = new Librarian(librarianName);
    Console.WriteLine($"Welcome {librarian.Name}");
    while (true)
    {
        // Books Function
        Console.WriteLine("Please choose to Add book (A) / Remove Book (R) / Display Books (D)");
        string userChoiseFnction = Console.ReadLine()!.ToUpper();
        char userTypeFunction = userChoiseFnction[0];
        Book book = new();
        switch (userTypeFunction)
        {
            case 'A':
                Console.WriteLine("Enter Book details");
                Console.Write("Book Title:"); string bookTitle = Console.ReadLine()!;
                Console.Write("Book Author:"); string bookAuthor = Console.ReadLine()!;
                Console.Write("Book Year:"); int bookYear = Convert.ToInt32(Console.ReadLine()!);

                book = new Book()
                {
                    Title = bookTitle,
                    Author = bookAuthor,
                    Year = bookYear
                };
                librarian.AddBook(book, library);
                break;

            case 'R':
                Console.WriteLine("Enter Book details to remove");
                Console.Write("Book Title:"); bookTitle = Console.ReadLine()!;
                Console.Write("Book Author:"); bookAuthor = Console.ReadLine()!;
                Console.Write("Book Year:"); bookYear = Convert.ToInt32(Console.ReadLine()!);
                book = new Book()
                {
                    Title = bookTitle,
                    Author = bookAuthor,
                    Year = bookYear
                };
                librarian.RemoveBook(book, library);
                break;

            case 'D':
                Console.WriteLine("The book list:");
                librarian.DisplayBooks(library);
                break;
            default:
                Environment.Exit(0);
                break;
        }
    }
}
else if (userType == 'R')
{
    // Welcome
    Console.Write("Welcome Library User, Enter your name: ");
    string UserName = Console.ReadLine()!;
    LibraryUser user = new(UserName);
    Console.WriteLine($"Welcome {user.Name}");
    while (true)
    {
        Console.WriteLine("Please choose to Borrow Book (B) / Display Books (D)");
        string userChoiseFunction = Console.ReadLine()!.ToUpper();
        char userTypeFunction = userChoiseFunction[0];
        switch (userTypeFunction)
        {
            case 'B':
                Console.WriteLine("Enter Book details to borrow");
                Console.Write("Book Title:"); string bookTitle = Console.ReadLine()!;
                Console.Write("Book Author:"); string bookAuthor = Console.ReadLine()!;
                Console.Write("Book Year:"); int bookYear = Convert.ToInt32(Console.ReadLine()!);

                Book book = new Book()
                {
                    Title = bookTitle,
                    Author = bookAuthor,
                    Year = bookYear
                };
                user.BorrowBook(book, library);
                break;
            case 'D':
                Console.WriteLine("The book list:");
                user.DisplayBooks(library);
                break;
            default:
                Environment.Exit(0);
                break;
        }
    }
}
else
{

}