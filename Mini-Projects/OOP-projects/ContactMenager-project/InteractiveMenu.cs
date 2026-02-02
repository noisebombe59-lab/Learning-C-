public class InteractiveMenu
{
    public static void MainMenu()
    {
        string? userChoice;
        do
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Добро пожаловать в Консольный менеджер контактов");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Меню команд");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("1.Добавить контакт");
            Console.WriteLine("2.Список контактов");
            Console.WriteLine("3.Поиск контакта");
            Console.WriteLine("4.Редактировать номер");
            Console.WriteLine("5.Удалить номер");
            Console.WriteLine("6.Выход\n");
            Console.Write("Введите команду: ");

            userChoice = Console.ReadLine();
            string[]? correctCommand = { "1", "2", "3", "4", "5", "6" };

            if (string.IsNullOrWhiteSpace(userChoice))
            {
                Console.WriteLine();
                Console.WriteLine("Неверная команда!\n");
                Console.ReadKey();
                continue;
            }

            if (!correctCommand.Contains(userChoice))
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка: введите от 1 до 6\n");
                Console.ReadKey();
                continue;
            }
            switch (userChoice)
            {
                case "1":
                    Console.Clear();

                    Contact newContact = CollectContactData();

                    ContactManager.AddContact(newContact);

                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("Контакт добавлен!");
                    Console.WriteLine("---------------------------------------------------------------------\n");
                    Console.WriteLine("Нажмите Enter, чтобы продолжить");
                    Console.ReadKey();
                    break;
                case "2":
                    ListAllContacts();
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Введите данные для поиска (имя, телефон и т.д.): ");
                    string? query = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(query))
                    {
                        Console.WriteLine("Строка не может быть null или пустой!");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("РЕЗУЛЬТАТ ПОИСКА: ");
                    Console.WriteLine("---------------------------------------------------------------------");

                    List<Contact> foundContacts = ContactManager.FindContact(query);
                    DisplayContactsInfo(foundContacts.ToArray());

                    Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Clear();

                    var contactNumber = 0;

                    if (ContactManager.Contacts.Length == 0)
                    {
                        Console.WriteLine("Список контактов пуст!\n");
                        Console.WriteLine("нажмите Enter, чтобы вернуться в главное меню");
                        Console.ReadKey();
                        break;
                    }

                    Console.Clear();

                    ListAllContacts();

                    Console.Write("Введите номер контакта: ");

                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out contactNumber))
                        {
                            Console.Write("Ошибка: введите число (номер контакта)!\n");
                            continue;
                        }
                        if (contactNumber <= 0 || contactNumber > ContactManager.Contacts.Length)
                        {
                            Console.WriteLine($"Ошибка: Контакт с номером {contactNumber} не существует.");
                            continue;
                        }
                        break;
                    }
                    ContactManager.EditContact(contactNumber);
                    break;
                case "5":
                    var contactNumberToDelete = 0;

                    if (ContactManager.Contacts.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Список контактов пуст!");
                        continue;
                    }

                    Console.Clear();

                    ListAllContacts();

                    Console.Write("Введите номер контакта для удаления: ");

                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out contactNumberToDelete))
                        {
                            Console.Write("Ошибка: введите номер еще раз: ");
                            continue;
                        }

                        if (contactNumberToDelete <= 0 || contactNumberToDelete > ContactManager.Contacts.Length)
                        {
                            Console.Write($"Ошибка: Контакт с номером [{contactNumberToDelete}] не существует, Попробуйте еще раз: ");
                            continue;
                        }

                        break;
                    }

                    ContactManager.RemoveContact(contactNumberToDelete);
                    Console.ReadKey();
                    break;
                case "6":
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("Выполнение программы завершено");
                    Console.WriteLine("---------------------------------------------------------------------");
                    return;
            }

        } while (userChoice != "6");
    }

    public static Contact CollectContactData()
    {
        Console.Write("Введите имя: ");

        string name = "";
        while (true)
        {
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя является обязательным полем.");
                continue;
            }
            break;
        }

        Console.Write("Введите Фамилию: ");
        string surName = "";

        while (true)
        {
            surName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surName))
            {
                Console.WriteLine("Фамилия является обязательным полем");
                continue;
            }
            break;
        }

        Console.Write("Введите Телефон (Enter = неизвестно): ");
        string? phone = null;

        while (true)
        {
            bool hasNonDigit = false;

            phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
            {
                break;
            }

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    hasNonDigit = true;
                    break;
                }
            }

            if (hasNonDigit)
            {
                Console.WriteLine("Ошибка: Телефон должен содержать только цифры. Попробуйте еще раз: ");
                continue;
            }

            if (phone.Length < 5 || phone.Length > 15)
            {
                Console.WriteLine("Ошибка: введите от 5 до 15 символов.Попробуйте еще раз: ");
                continue;
            }
            break;
        }

        Console.Write("Введите Email (Enter = неизвестно) : ");
        string? email = null;

        while (true)
        {
            email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!email.Contains("@gmail.com"))
                {
                    Console.WriteLine("Почта не содержит @gmail.com, попробуйте еще раз:  ");
                    continue;
                }
            }
            break;
        }

        int? age = GetAgeInputAndValidateFormat();

        Contact contact = new Contact
        {
            Name = name,
            Surname = surName,
            Phone = phone,
            Email = email,
            Age = age
        };

        return contact;
    }

    private static string Display(string? value, string defaultText = "не указано")
    => string.IsNullOrWhiteSpace(value) ? defaultText : value;

    private static string Display(int? value, string defaultText = "не указано")
        => value.HasValue ? value.ToString()! : defaultText;

    public static int? GetAgeInputAndValidateFormat()
    {
        while (true)
        {
            Console.Write("Введите возраст (Enter = неизвестно): ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (int.TryParse(input, out int age))
            {
                if (age >= 0 && age <= 120)
                    return age;
                else
                    Console.WriteLine("Возраст должен быть от 0 до 120 лет!");
            }
            else
            {
                Console.WriteLine("Введите корректное число!");
            }
        }
    }
    public static void DisplayContactsInfo(Contact[] contacts)
    {
        if (contacts.Length == 0)
        {
            Console.WriteLine("Совпадений не найдено.");
            return;
        }

        int contNum = 1;
        foreach (Contact contact in contacts)
        {
            Console.WriteLine($"Контакт номер:  ({contNum})");
            Console.WriteLine($"Имя: \t\t{contact.Name}");
            Console.WriteLine($"Фамилия: \t{contact.Surname}");
            Console.WriteLine($"Номер телефона: {Display(contact.Phone, "телефон неизвестен")}");
            Console.WriteLine($"Email:\t\t{Display(contact.Email, "Email неизвестен")}");
            Console.WriteLine($"Возраст:\t{Display(contact.Age, "возраст неизвестен")} \n");
            Console.WriteLine("---------------------------------------------------------------------");
            contNum++;
        }
    }

    public static void ListAllContacts()
    {
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine("--- СПИСОК КОНТАКТОВ ---");
        Console.WriteLine("---------------------------------------------------------------------");

        Contact[] contacts = ContactManager.Contacts;

        if (contacts.Length == 0)
        {
            Console.WriteLine("Список контактов пуст!");
            Console.WriteLine("Нажмите Enter, чтобы выйти в главное меню");
            return;
        }
        DisplayContactsInfo(contacts);
    }
}
