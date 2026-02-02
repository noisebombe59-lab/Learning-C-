public class ContactManager
{
    private readonly static List<Contact> _contacts = new List<Contact>();
    public static Contact[] Contacts { get => _contacts.ToArray(); }

    public static void AddContact(Contact contact)
    {
        if (contact == null)
        {
            Console.WriteLine("Объект контакта не может быть null.");
            return;
        }
        _contacts.Add(contact);
    }

    public static List<Contact> FindContact(string? query)
    {
        List<Contact> searchingResult = new List<Contact>();

        string search = (query ?? "").Trim().ToLower();

        foreach (Contact? contact in _contacts)
        {
            if (contact.Name.ToLower().Contains(search) ||
                contact.Surname.ToLower().Contains(search) ||
               (contact.Phone ?? "").ToLower().Contains(search) ||
               (contact.Email ?? "").ToLower().Contains(search) ||
               (contact.Age?.ToString() ?? "").Contains(search))
            {
                searchingResult.Add(contact);
            }
        }
        return searchingResult;
    }

    public static Contact? GetContactByIndex(int index)
    {

        int listIndex = ContactNumberToInternalIndex(index);

        if (listIndex >= 0 && listIndex < _contacts.Count)
        {
            return _contacts[listIndex];
        }

        return null;
    }

    private static int ContactNumberToInternalIndex(int listIndex)
    {
        return listIndex - 1;
    }

    public static void EditContact(int contactNumber)
    {
        string? continueOperation = "";

        Contact? contactToEdit = GetContactByIndex(contactNumber);

        do
        {
            Console.Clear();
            Console.WriteLine($"--- РЕДАКТИРОВАНИЕ КОНТАКТА [{contactNumber}] ---");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Текущее Имя: {contactToEdit.Name}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить старое значение.");
            Console.WriteLine("---------------------------------------------------------------------\n");

            Console.Write("Введите новое имя: ");
            while (true)
            {
                string? newName = Console.ReadLine();
                Console.WriteLine();

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    contactToEdit.Name = newName;
                    break;
                }
                break;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Текущая Фамилия: {contactToEdit.Surname}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить старое значение.");
            Console.WriteLine("---------------------------------------------------------------------\n");

            Console.Write("Введите новую фамилию: ");
            while (true)
            {
                string? newSurname = Console.ReadLine();
                Console.WriteLine();

                if (!string.IsNullOrWhiteSpace(newSurname))
                {
                    contactToEdit.Surname = newSurname;
                    break;
                }
                break;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Текущий Номер телефона: {contactToEdit.Phone}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить старое значение.");
            Console.WriteLine("---------------------------------------------------------------------\n");

            Console.Write("Введите новый номер телефона: ");
            string? newPhone = null;

            while (true)
            {
                bool hasNonDigit = false;

                newPhone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newPhone))
                {
                    contactToEdit.Phone = null;
                    break;
                }

                foreach (char c in newPhone)
                {
                    if (!char.IsDigit(c))
                    {
                        hasNonDigit = true;
                        break;
                    }
                }

                if (hasNonDigit)
                {
                    Console.Write("Ошибка: Телефон должен содержать только цифры. Попробуйте еще раз: ");
                    continue;
                }

                if (newPhone.Length < 5 || newPhone.Length > 15)
                {
                    Console.Write("Ошибка: введите от 5 до 15 символов. Попробуйте еще раз: ");
                    continue;
                }

                contactToEdit.Phone = newPhone;
                break;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Текущий Email: {contactToEdit.Email}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить старое значение.");
            Console.WriteLine("---------------------------------------------------------------------\n");

            Console.Write("Введите новый Email: ");
            while (true)
            {
                string? newEmail = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(newEmail))
                {
                    contactToEdit.Email = null;
                    break;
                }
                if (!newEmail.Contains("@gmail.com"))
                {
                    Console.Write("Почта не содержит @gmail.com, попробуйте еще раз: ");
                    continue;
                }

                contactToEdit.Email = newEmail;
                break;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Текущий Возраст: {contactToEdit.Age}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Оставьте поле пустым, чтобы сохранить старое значение.");
            Console.WriteLine("---------------------------------------------------------------------\n");

            Console.Write("Введите новый возраст: ");
            while (true)
            {
                string? inputAge = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputAge))
                {
                    contactToEdit.Age = null;
                    break;
                }
                if (int.TryParse(inputAge, out int newAge))
                {
                    Console.WriteLine();
                    contactToEdit.Age = newAge;
                    break;
                }
                Console.WriteLine("Ошибка: Возраст должен быть числом. Попробуйте еще раз.");
                continue;
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Контакт успешно обновлен");
            Console.WriteLine("---------------------------------------------------------------------\n");

            while (true)
            {
                Console.Write("Хотите продолжить y/n?: ");

                continueOperation = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(continueOperation))
                {
                    Console.WriteLine("Строка не может быть null или пустой!");
                    continue;
                }
                if (continueOperation != "n" && continueOperation != "y")
                {
                    Console.Write("Ошибка: введите y/n: ");
                    continue;
                }
                break;
            }
        } while (continueOperation != "n");
    }

    public static void RemoveContact(int getNumberToDelete)
    {
        int lastIndex = ContactNumberToInternalIndex(getNumberToDelete);

        if (lastIndex >= 0 && lastIndex < _contacts.Count)
        {
            Console.WriteLine($"--- Удаление КОНТАКТА [{getNumberToDelete}] ---");

            _contacts.RemoveAt(lastIndex);

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Контакт успешно удалён!");
            Console.WriteLine("---------------------------------------------------------------------");

        }
    }
}
