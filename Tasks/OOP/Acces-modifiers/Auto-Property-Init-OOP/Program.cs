class Program
{
    static void Main(string[] args)
    {
        try
        {
            Book book = new Book { Title = "Краткая история времен", Author = "Стивен Хоккинг", Year = 1980 };
            PrintInfo(book);

            Book book2 = new Book { Title = "Гарри Поттер", Author = "Д.К. Роуллинг", Year = 1990 };
            PrintInfo(book2);

            Book book3 = new Book { Title = "", Author = "", Year = 0 };
            PrintInfo(book3);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void PrintInfo(Book book)
    {
        Console.WriteLine($"Название: {book.Title}");
        Console.WriteLine($"Автор: {book.Author}");
        Console.WriteLine($"Год выпуска: {book.Year}");
        Console.Write("Статус книги: ");
        book.Borrow();
        Console.WriteLine();
    }
}