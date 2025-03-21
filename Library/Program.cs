using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    class Book
    {
        public Book(string title, string author, string iSBN, bool availability)
        {
            this.title = title;
            this.author = author;
            this.ISBN = iSBN;
            this.availability = availability;
        }

        public string title { get; private set; }
        public string author { get; private set; }
        public string ISBN { get; private set; }
        public bool availability { get; private set; }

        public void Borrow()
        {
            availability = false;
        }
        public void Return()
        {
            availability = true;
        }
    }
    class Library
    {
        private List<Book> books = new List<Book>();

        public void addBook(Book book)
        {
            books.Add(book);
        }
        public Book searchBook(string query)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    books[i].author.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    return books[i];
                }

            }
            return null;
        }
        public bool BorrowBook(string query)
        {
            Book book = searchBook(query);
            if (book != null && book.availability)
            {
                book.Borrow();
                return true;
            }
            return false;
        }
        public bool ReturnBook(string query)
        {
            Book book = searchBook(query);
            if (book != null && !book.availability)
            {
                book.Return();
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Library library = new Library();

            // Adding books to the library
            library.addBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", true));
            library.addBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", true));
            library.addBook(new Book("1984", "George Orwell", "9780451524935", true));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine(library.BorrowBook("Gatsby") ? "Borrowed successfully." : "Book not found or unavailable.");
            Console.WriteLine(library.BorrowBook("1984") ? "Borrowed successfully." : "Book not found or unavailable.");
            Console.WriteLine(library.BorrowBook("Harry Potter") ? "Borrowed successfully." : "Book not found or unavailable.");// This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            Console.WriteLine(library.ReturnBook("Gatsby") ? "Returning successfully." : "Book not found or unavailable.");
            Console.WriteLine(library.ReturnBook("Harry Potter") ? "Returning successfully." : "Book not found or unavailable.");// This book is not borrowed

            Console.ReadLine();
        }
    }
}
