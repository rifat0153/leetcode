using Leetcode.DesignPatterns.Models;

namespace Leetcode.DesignPatterns.Specification;

internal class BookValidator(IEnumerable<Specification<Book>> specifications)
{
    public bool IsValid(Book book) => Specifications.All(specifications.ToArray())(book);
}
