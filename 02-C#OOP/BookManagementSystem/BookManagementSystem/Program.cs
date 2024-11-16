
using BookManagementApp;

List<Book> books = new List<Book>(); // List to store registered books.
Utilities.CheckForExistingBookFile(); // Placeholder to check if a file with book data exists.

bool running = true;

// Main menu loop
do
{
    Console.Clear(); // Clear the console for a clean look.
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Book Management Application");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Books Loaded: {books.Count}");
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Register a Book");
    Console.WriteLine("2. View All Books");
    Console.WriteLine("3. Save Books to File (TODO)");
    Console.WriteLine("4. Load Books from File (TODO)");
    Console.WriteLine("9. Quit");

    Console.Write("\nSelect an option: ");
    string userSelection = Console.ReadLine()!;

    switch (userSelection)
    {
        case "1":
            Utilities.RegisterBook(books); // Register a new book.
            break;
        case "2":
            Utilities.ViewBooks(books); // View all registered books.
            break;
        case "3":
            Utilities.SaveBooksToFile(books);
            break;
        case "4":
            Utilities.LoadBooksFromFile(books);
            break;
        case "9":
            running = false; // Exit the application.
            break;
        default:
            Console.WriteLine("Invalid selection, please try again.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

} while (running);

Console.WriteLine("Thanks for using the Book Management Application!");
