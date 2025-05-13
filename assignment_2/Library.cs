using System;

class Book
{
    public string Code;
    public string Name;

    public Book(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine($"Code: {Code}, Name: {Name}");
    }
}

class Library
{
    static void Main()
    {
        Book[] books = new Book[3];
        for (int i = 0; i < books.Length; i++)
        {
            Console.Write("Enter book code: ");
            string code = Console.ReadLine();
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();
            books[i] = new Book(code, name);
        }

        Console.WriteLine("\nLibrary Book List:");
        foreach (Book b in books)
        {
            b.Display();
        }
    }
}
