
namespace BookManagementApp
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }

        public Book(string title, string author, string genre, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublicationDate = publicationDate;
        }

        public void DisplayBookDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Publication Date: {PublicationDate.ToShortDateString()}");
        }
    }
}
