using ConsoleApp1.DesignPatterns.Models;

namespace ConsoleApp1.DesignPatterns.Specification;

internal static class BookSpecifications
{
    public static Specification<Book> IsAvailable() => book => book.Stock > 0;

    public static Specification<Book> HasMinimumRating(double rating) =>
        book => book.Rating >= rating;

    public static Specification<Book> IsWrittenBy(string author) =>
        book => book.Authors.Any(a => string.Equals(author, a.Name));
}
