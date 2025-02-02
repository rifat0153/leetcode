using ConsoleApp1.DesignPatterns.Models;
using LanguageExt;

namespace ConsoleApp1.DesignPatterns.Currying;

internal class CurryingExample
{
    public delegate IEnumerable<Book> ProcessBooks(IEnumerable<Book> books, int stock, int rating);

    public static void Run()
    {
        // Original function
        ProcessBooks processBooks = (books, stock, rating) =>
            books.Where(book => book.Stock >= stock && book.Rating >= rating);

        // Curried function
        var curriedProcessBooks = Prelude.curry<IEnumerable<Book>, int, int, IEnumerable<Book>>(
            processBooks.Invoke
        );

        // Example books
        List<Book> books =
        [
            new Book("Book 1", [new Author("Author 1", "Surname 1", 30)], 10, 4),
            new Book("Book 2", [new Author("Author 2", "Surname 2", 40)], 2, 3),
            new Book(
                "Book 3",
                [new Author("Author 3 ", "Surname 3", 50), new Author("Author 2", "Surname 2", 40)],
                5,
                5
            ),
        ];

        // Curried function usage
        List<IEnumerable<Book>> result = [];

        Func<int, Func<int, IEnumerable<Book>>> curriedProcessBooksStock = curriedProcessBooks(
            books
        );

        Func<int, IEnumerable<Book>> booksWithRating4 = curriedProcessBooksStock(4);
        var booksWithRating3 = curriedProcessBooksStock(3);

        var bookWithRating4AndStock3 = booksWithRating4(3);
        var bookWithRating3AndStock2 = booksWithRating3(2);
        var bookWithRating3AndStock5 = booksWithRating3(5);
        var bookWithRating5AndStock5 = booksWithRating4(5);

        result.Add(bookWithRating4AndStock3);
        result.Add(bookWithRating3AndStock2);
        result.Add(bookWithRating3AndStock5);
        result.Add(bookWithRating5AndStock5);

        Console.WriteLine("Curried function result:");

        result
            .Select(x => string.Join(", ", x.Select(book => $"{book} \n").ToList()) + "\n")
            .ToList()
            .ForEach(Console.WriteLine);
    }
}
