using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // LIST<T>:
        // Ordered collection of books available in the library
        var books = new List<Book>
        {
            new Book(1, "Clean Code"),
            new Book(2, "The Pragmatic Programmer"),
            new Book(3, "Design Patterns")
        };

        // LIST<T>:
        // Ordered collection of registered library members
        var members = new List<Member>
        {
            new Member(1, "Alice"),
            new Member(2, "Bob")
        };

        // BUSINESS LOGIC IS DELEGATED TO A SERVICE
        var borrowingService = new BorrowingService(books, members);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Library Borrowing System ===");
            Console.WriteLine("1. Borrow a book");
            Console.WriteLine("2. View member borrowing history");
            Console.WriteLine("0. Exit");
            Console.Write("Select option: ");

            // USER-DRIVEN WORKFLOW:
            var choice = Console.ReadLine();

            // RUNTIME DECISION-MAKING:
            switch (choice)
            {
                case "1":
                    BorrowBook(borrowingService);
                    break;

                case "2":
                    ViewHistory(borrowingService);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void BorrowBook(BorrowingService service)
    {
        Console.Clear();

        Console.Write("Enter Member ID: ");
        if (!int.TryParse(Console.ReadLine(), out var memberId))
            return;

        Console.Write("Enter Book ID: ");
        if (!int.TryParse(Console.ReadLine(), out var bookId))
            return;

        try
        {
            // PROGRAM.CS DOES NOT DECIDE VALIDITY
            // It delegates the borrowing decision to the service
            service.BorrowBook(memberId, bookId);
            Console.WriteLine("Book borrowed successfully.");
        }
        catch (Exception ex)
        {
            // USER FEEDBACK ONLY
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private static void ViewHistory(BorrowingService service)
    {
        Console.Clear();

        Console.Write("Enter Member ID: ");
        if (!int.TryParse(Console.ReadLine(), out var memberId))
            return;

        // LINQ QUERY RESULT FROM SERVICE
        var history = service.GetBorrowHistoryForMember(memberId);

        Console.WriteLine("\nBorrow History:");
        foreach (var record in history)
        {
            Console.WriteLine(
                $"BookId: {record.BookId}, Borrowed At: {record.BorrowedAt}"
            );
        }

        Console.ReadKey();
    }
}
