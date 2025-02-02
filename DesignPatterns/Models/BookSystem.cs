namespace ConsoleApp1.DesignPatterns.Models;

internal record Book(string Title, Author[] Authors, int Stock, int Rating);

internal record Author(string Name, string Surname, int Age);
