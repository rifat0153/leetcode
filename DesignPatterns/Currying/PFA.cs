namespace Leetcode.DesignPatterns.Currying;

using System;
using System.Linq;
using LanguageExt;

// --- Domain Models ---
public record Product(string Name, decimal Price);

public record Order(string OrderId, string CustomerName, Product[] Products);

// --- Formatting Logic ---

public delegate string FormatOrderDelegate(Order order);
public delegate string FormatOrdersDelegate(FormatOrderDelegate formatter, Order[] orders);

// --- Formatters ---

public static class InvoiceFormatters
{
    // Formatter for CSV format
    public static FormatOrderDelegate CsvFormatter = order =>
        $"{order.OrderId}, {order.CustomerName}, {string.Join(", ", order.Products.Select(p => $"{p.Name} ({p.Price:C})"))}";

    // Formatter for JSON format
    public static FormatOrderDelegate JsonFormatter = order =>
        $"{{\"OrderId\": \"{order.OrderId}\", \"Customer\": \"{order.CustomerName}\", \"Products\": [{string.Join(", ", order.Products.Select(p => $"{{\"Name\": \"{p.Name}\", \"Price\": {p.Price}}}"))}]}}";

    // Formatter for PDF format (simplified)
    public static FormatOrderDelegate PdfFormatter = order =>
        $"Invoice for Order ID: {order.OrderId}\nCustomer: {order.CustomerName}\nProducts:\n{string.Join("\n", order.Products.Select(p => $"- {p.Name}: {p.Price:C}"))}";
}

// --- Invoice Generator ---

public static class InvoiceGenerator
{
    // Function for generating an invoice (formats all orders)
    public static string GenerateInvoice(FormatOrderDelegate formatOrder, Order[] orders)
    {
        return string.Join("\n", orders.Select(formatOrder.Invoke));
    }
}

// --- Program (Using Partial Function Application) ---

public static class Program
{
    public static void Main()
    {
        // Example products
        Product[] products =
        [
            new Product("Laptop", 1200.00m),
            new Product("Mouse", 25.00m),
            new Product("Keyboard", 45.00m),
        ];

        // Example orders
        Order[] orders =
        [
            new Order("ORD123", "John Doe", products),
            new Order("ORD124", "Jane Smith", products),
        ];

        // Curried function to generate invoices in different formats
        var curriedGenerateInvoice = Prelude.curry<FormatOrderDelegate, Order[], string>(
            InvoiceGenerator.GenerateInvoice
        );

        // Partially apply the curried function for different formats
        Func<Order[], string> generateCsvInvoice = curriedGenerateInvoice(
            InvoiceFormatters.CsvFormatter
        );
        Func<Order[], string> generateJsonInvoice = curriedGenerateInvoice(
            InvoiceFormatters.JsonFormatter
        );
        Func<Order[], string> generatePdfInvoice = curriedGenerateInvoice(
            InvoiceFormatters.PdfFormatter
        );

        // Generate invoices
        string csvInvoice = generateCsvInvoice(orders);
        string jsonInvoice = generateJsonInvoice(orders);
        string pdfInvoice = generatePdfInvoice(orders);

        // Output the invoices
        Console.WriteLine("CSV Invoice:");
        Console.WriteLine(csvInvoice);

        Console.WriteLine("\nJSON Invoice:");
        Console.WriteLine(jsonInvoice);

        Console.WriteLine("\nPDF Invoice:");
        Console.WriteLine(pdfInvoice);
    }
}
