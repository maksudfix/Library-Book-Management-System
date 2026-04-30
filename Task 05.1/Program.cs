using System;
using System.Collections.Generic;
class Author
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Bio { get; set; }
    public List<Book> Books { get; set; }
    public Author(string name, DateTime dateofbirth, string bio)
    {
        Name = name;
        DateOfBirth = dateofbirth;
        Bio = bio;
        Books = new List<Book>();
    }
    public void DisplayAuthorInfo()
    {
        Console.WriteLine($"Author Name: {Name}");
        Console.WriteLine($"Author Bio: {Bio}");
        Console.WriteLine($"Author Date of Birth: {DateOfBirth.ToShortDateString()}");
    }
    public void AddAuthorBook(Book book)
    {
        Books.Add(book);
    }
}
class Book
{
    public string Title { get; set; }
    public Author Author { get; set; }
    public long ISBN { get; set; }
    public int BookID { get; set; }
    public string Genre { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; internal set; }

    public Book (string title,Author author, long isbn, int bookid, string genre, double price)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        BookID = bookid;
        Genre = genre;
        Price = price;
        IsAvailable = true;
    }
    public void DisplayBookInfo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Book Title: {Title}");
        Console.WriteLine($"Author Name: {Author.Name}");
        Console.WriteLine($"Book ISBN: {ISBN}");
        Console.WriteLine($"Book Genre: {Genre}");
        Console.WriteLine($"Book Price: {Price} BDT");
        Console.WriteLine($"Book Availability: {(IsAvailable ? "Available" : "Not Available")}\n");
        Console.ResetColor();
    }
}
class Library
{
    public string LibraryName { get; set; }
    public string Location { get; set; }
    public string ContactInfo { get; set; }
    public List<Book> Books { get; set; }
    public bool IsAvailable { get; internal set; }
    public Library(string libraryName, string location, string contactInfo)
    {
        LibraryName = libraryName;
        Location = location;
        ContactInfo = contactInfo;
        Books = new List<Book>();
        IsAvailable = true;
    }
    public void DisplayLibraryDetails()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("---Library Details---\n");
        Console.WriteLine($"Name of the Library: {LibraryName}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Contact Information: {ContactInfo}");
        Console.ResetColor();
    }
    public void AddBookToLibrary(Book book)
    {
        Books.Add(book);
    }
    public void RemoveBookFromLibrary(Book book)
    {
        Books.Remove(book);
    }
    public void SearchBook(int bookID)
    {
        Book found = null; 
        foreach(var book in Books)
        {
            if (book.BookID == bookID)
            {
                found = book;
                break;
            } 
        }
        if (found == null)
        {
            Console.WriteLine("Not Available in the Library");
            return;
        }
        Console.WriteLine($"Book is Available in the Library");
        found.DisplayBookInfo();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("What you want to do with the book?");
        Console.WriteLine("1. Borrow the book");
        Console.WriteLine("2. Return the book");
        Console.WriteLine("3. Purchase the book\n");
        Console.ResetColor();
        Console.Write("Enter Option: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BorrowBook(bookID);
                break;
            case 2:
                ReturnBook(bookID);
                break;
            case 3:
                BuyBook(bookID);
                break;
            default:
                Console.WriteLine("Invalid Option. Please try again.");
                break;
        }
    }
    public void BorrowBook(int bookID)
    {
        foreach (var book in Books)
        {
            if (book.BookID == bookID)
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"The book {book.Title} is available.You can borrow it.");
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                }
                return;
            }  
        }
        Console.WriteLine("Sorry! The book is not available for borrowing.");
    }
    public void ReturnBook(int bookID)
    {
        foreach (var book in Books)
        {
            if (book.BookID == bookID)
            {
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"The Book {book.Title} is returned. Thanks For Returning.");
                }
                else
                {
                    Console.WriteLine("Book was not borrowed yet.");
                }
                return;
            }
        }
        Console.WriteLine("Sorry! The book is not available at this moment.");
    }
    public void BuyBook(int bookId)
    {
        Book found = null;
        foreach (var book in Books)
        {
            if (book.BookID == bookId)
            {
                found = book;
                break;
            }  
        }
        if (found != null)
        {
            Console.WriteLine($"Price: {found.Price} BDT");
            Books.Remove(found);
            Console.WriteLine("Purchase successful! Thank you for buying the book.");
        }
        else
        {
            Console.WriteLine("Sorry! The book is not available for purchase.");
        }
    }
}
class LibraryBookManagementSystem
{
    static void Main()
    {
        Author author1 = new Author("J.K. Rowling", new DateTime(1965, 07, 31), "British author, best known for the Harry Potter series.");
        Author author2 = new Author("Franklin Patrick Herbert Jr.", new DateTime(1920, 08, 10), " American author, who wrote the seminal 1965 science fiction novel Dune.");
        Author author3 = new Author("Kazi Nazrul Islam", new DateTime(1899, 05, 24), "Bangladeshi poet, musician and revolutionary, known as the Rebel Poet.");
        Author author4 = new Author("Bibhutibhushan Bandyopadhyay", new DateTime(1894, 09, 12), "Indian Bengali author, best known for Pather Panchali.");
        Author author5 = new Author("Rabindranath Tagore", new DateTime(1861, 05, 07), "Bengali polymath, poet, writer, and Nobel laureate.");

        Book book1 = new Book("Harry Potter and the Sorcerer's Stone", author1, 9780439708180, 220, "Fantasy", 299.9);
        Book book2 = new Book("Dune",author2, 9780441172719, 221, "Science Fiction", 380.0);
        Book book3 = new Book("Bidrohi", author3, 9789848765432, 222, "Poetry", 150.0);
        Book book4 = new Book("Pather Panchali", author4, 9788172235785, 223, "Novel", 320.0);
        Book book5 = new Book("Gitanjali", author5, 9788129118927, 224, "Poetry", 250.0);

        Library library = new Library("Park Street Books", "Road No.09, Sector No. 10, Uttara, Dhaka", "Email: psbook10@gmail.com & CellPhone: 017540702**");
        library.AddBookToLibrary(book1);
        library.AddBookToLibrary(book2);
        library.AddBookToLibrary(book3);
        library.AddBookToLibrary(book4);
        library.AddBookToLibrary(book5);

        library.DisplayLibraryDetails();
        while(true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nEnter Book ID to Search: ");
            Console.ResetColor();
            int bookID = int.Parse(Console.ReadLine());
            if (bookID == 0)
                break;
            library.SearchBook(bookID);
        }
        Console.WriteLine();
    }
}
  