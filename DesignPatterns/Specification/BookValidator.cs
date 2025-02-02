using ConsoleApp1.DesignPatterns.Models;

namespace ConsoleApp1.DesignPatterns.Specification;

internal class BookValidator(IEnumerable<Specification<Book>> specifications)
{
    public bool IsValid(Book book) => Specifications.All(specifications.ToArray())(book);
}
