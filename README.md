# Library Book Management System

A simple C# Console Application that manages a library's authors, books, availability, borrowing, returning, purchasing, and book searching using classes, objects, properties, lists, constructors, and object relationships.

## Features

* Store multiple authors and books
* Store author information and biographies
* Add books to the library
* Search books by Book ID
* Display book details and availability
* Borrow and return books
* Purchase and remove books from the library
* Track book availability
* Use a continuous search menu until `0` is entered

## Code Structure

Author
 ├── Name
 ├── DateOfBirth
 ├── Bio
 ├── Books
 ├── DisplayAuthorInfo()
 └── AddAuthorBook()

Book
 ├── Title
 ├── Author
 ├── ISBN
 ├── BookID
 ├── Genre
 ├── Price
 ├── IsAvailable
 └── DisplayBookInfo()

Library
 ├── LibraryName
 ├── Location
 ├── ContactInfo
 ├── Books
 ├── DisplayLibraryDetails()
 ├── AddBookToLibrary()
 ├── RemoveBookFromLibrary()
 ├── SearchBook()
 ├── BorrowBook()
 ├── ReturnBook()
 └── BuyBook()

LibraryBookManagementSystem
 └── Main()
      ├── Create Authors
      ├── Create Books
      ├── Create Library
      ├── Add Books
      └── Search & Manage Books

## Concepts Used

* Classes & Objects — Represents authors, books, and the library.
* Encapsulation — Uses properties to manage data.
* Constructors — Initializes authors, books, and library information.
* List<T> — Stores multiple books and authors' books.
* Object Relationships — A `Book` contains an `Author`, while a `Library` contains multiple books.
* foreach — Searches and processes books in the library.
* CRUD Operations — Add, search, borrow, return, and purchase/remove books.
* Boolean State — `IsAvailable` tracks whether a book is available.
* Loop & Switch — Provides continuous book searching and action selection.

## Technologies

**C# • .NET Console Application • Classes • Objects • Properties • Constructors • List<T> • Object Relationships • foreach • Loops • Switch Statements • Console I/O**
