using System;

public class Book
{
    public string Code { get; set; }
    public string Name { get; set; }

    // Constructor
    public Book(string code, string name)
    {
        Code = code;
        Name = name;
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the number of books in the library: ");
        int numBooks = Convert.ToInt32(Console.ReadLine());

        // Declare array of Book objects
        Book[] library = new Book[numBooks];

        // Input book details
        for (int i = 0; i < numBooks; i++)
        {
            Console.WriteLine($"\nEnter details for Book {i + 1}:");

            Console.Write("Enter Book Code: ");
            string code = Console.ReadLine();

            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

            // Store in array
            library[i] = new Book(code, name);
        }

        // Display all books
        Console.WriteLine("\nBooks in the Library:");
        Console.WriteLine("----------------------");
        foreach (Book book in library)
        {
            Console.WriteLine($"Code: {book.Code}, Name: {book.Name}");
        }
    }
}
