using System;

class Book
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Book (string code, string name)
    {
        Code = code;
        Name = name;
    }

    public void Display ()
    {
        Console.WriteLine($"Book Code: {Code}, Book Name: {Name}");
    }
}

class Library
{
    static void Main ()
    {
        Console.WriteLine("Enter the number of books in the library: ");
        int n = int.Parse(Console.ReadLine());

        Book[] books = new Book[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for book #{i + 1}:");
            Console.Write("Enter Book Code: ");
            string code = Console.ReadLine();

            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

            books[i] = new Book(code, name);
        }

        Console.WriteLine("\nBooks in the library: ");
        for (int i = 0;i < n;i++)
        {
            books[i].Display();
        }
    }
}