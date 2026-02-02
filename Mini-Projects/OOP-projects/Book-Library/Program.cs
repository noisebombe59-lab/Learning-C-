namespace Book_Library
{
    public class Program
    {
        private static Library library = new Library();  // один на всю программу, чтобы книги были в одной библиотеке
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("=== Библиотека книг ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Взять книгу");
                Console.WriteLine("3. Вернуть книгу");
                Console.WriteLine("4. Поиск по автору");
                Console.WriteLine("5. Список всех книг");
                Console.WriteLine("6. Выход");
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("Выберите команду: ");

                string[]? allCommands = { "1", "2", "3", "4", "5", "6" };

                string? userChoice = Console.ReadLine();
                if (string.IsNullOrEmpty(userChoice))
                {
                    Console.WriteLine("Ошибка: Выберите команду из списка");
                    Console.ReadKey();
                    continue;
                }

                if (!allCommands.Contains(userChoice))
                {
                    Console.WriteLine("Ошибка: выберите от 1 до 6");
                    Console.ReadKey();
                    continue;
                }

                switch (userChoice)
                {
                    case "1":
                        try
                        {
                            Console.Clear();
                            CollectDataToAdd();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        GetBook();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        ReturnBook();
                        break;
                    case "4":
                        Console.Clear();
                        FindBooks();
                        break;
                    case "5":
                        Console.Clear();
                        AllBooksInLibrary();
                        Console.ReadKey();
                        break;
                    case "6":
                        return;
                }
            }
        }

        public static void CollectDataToAdd()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите название книги: ");
                    string title = Console.ReadLine();

                    Console.Write("Введите имя автора: ");
                    string author = Console.ReadLine();

                    Console.Write("Введите год выпуска: ");
                    int year = 0;

                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out year))
                        {
                            Console.Write("Год выпуска должен быть целым числом!: ");
                            continue;
                        }
                        break;
                    }

                    Book book = new Book(title, author, year);

                    library.AddBook(book);
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Книга добавлена");
                    Console.WriteLine("-------------------------------------------------------");
                    Console.ReadKey();
                    return;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ошибка: год должен быть числом. Попробуйте ещё раз.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message} Попробуйте ещё раз.");
                }
            }
        }

        public static void GetBook()
        {

            if (!AllBooksInLibrary())
            {
                return;
            }

            List<Book> bookList = library.GetBooksList();

            int bookNumber = 0;
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Чтобы взять книгу, введите номер: ");

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out bookNumber))
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine($"Номер книги должен быть целым числом!");
                    continue;
                }
                if (bookNumber <= 0)
                {
                    Console.Write("Ошибка: номер книги не может быть отрицательным");
                    continue;
                }
                if (bookNumber > bookList.Count)
                {
                    Console.Write($"Книги с номером ({bookNumber}) не существует, попробуйте еще раз: ");
                    continue;
                }

                Book book = library.GetBookByNumber(bookNumber);

                if (library.Borrow(book))
                {
                    Console.WriteLine($"Успех: Вы взяли книгу '{book.Title}'.");

                }
                else
                {
                    Console.WriteLine($"Ошибка: Книга '{book.Title}' сейчас недоступна.");
                }
                break;
            }
        }

        public static void ReturnBook()
        {
            List<Book> bookList = library.GetBooksList();
            bool isFound = false;

            if (bookList.Count == 0)
            {
                Console.WriteLine("Библиотека пуста — нет книг для возврата");
                Console.ReadKey();
                return;
            }

            Console.Write("Чтобы вернуть книгу, введите название: ");
            string bookToReturn = "";

            while (true)
            {
                bookToReturn = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(bookToReturn))
                {
                    Console.WriteLine("Ошибка, некорректное название, попробуйте еще раз: ");
                    continue;
                }

                foreach (var book in bookList)
                {

                    if (book.Title.Equals(bookToReturn, StringComparison.OrdinalIgnoreCase))
                    {
                        if (library.Return(book))
                        {
                            Console.WriteLine($"Успех: Вы вернули книгу '{bookToReturn}'");
                        }
                        else
                        {
                            Console.WriteLine($"Книга '{bookToReturn}' уже возвращена");
                            Console.ReadKey();
                            return;
                        }
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine($"Книга с именем {bookToReturn} не найдена");
                }
                Console.ReadKey();
            }
        }

        public static void FindBooks()
        {
            while (true)
            {
                Console.Write("Для поиска введите имя автора: ");
                string author = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Ошибка: некорректное имя автора для поиска, попробуйте еще раз");
                    continue;
                }

                List<Book> findedBooks = library.FindByAuthor(author);

                if (findedBooks.Count == 0)
                {
                    Console.WriteLine($"Книги автора ({author}) не найдены!");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Книги автора ({author}) найдены!");
                    int newBookNumber = 1;
                    foreach (Book book in findedBooks)
                    {
                        PrintInfo(book, newBookNumber);
                        newBookNumber++;
                    }
                }

                Console.Write("Хотите продолжить поиск? y/n\n");

                while (true)
                {
                    string continueWord = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(continueWord))
                    {
                        if (continueWord.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }
                        if (continueWord.Equals("n", StringComparison.OrdinalIgnoreCase))
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.Write("Ошибка: Введите y/n: ");
                        continue;
                    }
                }
            }
        }

        public static void PrintInfo(Book book, int bookNumber)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Книга {bookNumber}");
            Console.WriteLine($"Название: {book.Title}");
            Console.WriteLine($"Автор: {book.Author}");
            Console.WriteLine($"Год выпуска: {book.Year}");
            Console.WriteLine($"Статус книги: {(book.IsAvailable ? "Доступна" : "Взята")}");
            Console.WriteLine("-------------------------------------------------------");
            bookNumber++;
        }

        public static bool AllBooksInLibrary()
        {
            List<Book> books = library.GetBooksList();
            int bookNumber = 1;

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("СПИСОК КНИГ В БИБЛИОТЕКЕ");
            Console.WriteLine("---------------------------------------------------------------------");

            if (books.Count == 0)
            {
                Console.WriteLine("Галерея пуста!");
                return false;
            }
            foreach (Book book in books)
            {
                PrintInfo(book, bookNumber);
                bookNumber++;
            }
            return true;
        }
    }
}