using System;

class Book
{
    public string Code { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("How many books are in the library?");
        int numBooks = Convert.ToInt32(Console.ReadLine());
        
        Book[] library = new Book[numBooks];
        
        // Input book details
        for (int i = 0; i < numBooks; i++)
        {
            Console.WriteLine($"\nEnter details for Book {i + 1}:");
            
            Book book = new Book();
            
            Console.Write("Enter book code: ");
            book.Code = Console.ReadLine();
            
            Console.Write("Enter book name: ");
            book.Name = Console.ReadLine();
            
            library[i] = book;
        }
        
        // Display all books
        Console.WriteLine("\nLibrary Book List:");
        Console.WriteLine("------------------");
        Console.WriteLine("Code\tName");
        Console.WriteLine("------------------");
        
        foreach (Book book in library)
        {
            Console.WriteLine($"{book.Code}\t{book.Name}");
        }
    }
}