namespace ConsoleApp1.DesignPatterns.Specification;

public delegate bool Specification<T>(T item);

public static class Specifications
{
    public static Specification<T> And<T>(this Specification<T> left, Specification<T> right) =>
        item => left(item) && right(item);

    public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right) =>
        item => left(item) || right(item);

    public static Specification<T> Not<T>(this Specification<T> spec) => item => !spec(item);

    public static Specification<T> All<T>(params Specification<T>[] specs) =>
        item => specs.All(spec => spec(item));
}
