/*
 * Сбор данных (Цикл + Методы + Try/Catch):
Создай метод GetUserDetails(), который в цикле собирает данные: Имя, Возраст, Секретный Код.
Для Имени: Используй твой метод NormalizeName() (с проверкой на пробелы и цифры).
Если имя не прошло нормализацию, выведи ошибку и попроси ввести снова.
Для Возраста: Используй метод с try-catch (или TryParse) для валидации:
должен быть целым числом от 18 до 99. Лови FormatException.
Для Секретного Кода: Примени string.IsNullOrWhiteSpace() и проверь, 
что длина кода ровно 8 символов.
Хранение данных (Коллекции);
Сохрани все успешно собранные данные (Имя, Возраст, Код) 
в коллекции Dictionary<string, string> 
(ключ: "Имя", "Возраст", "Код", значение: соответствующие данные).
Финальный вывод (Форматирование):
После успешного сбора всех данных, используй цикл foreach по словарю 
и интерполяцию строк ($"") для вывода всех собранных данных пользователю в 
форматированном виде*/

static Dictionary<string, string> GetUserDetails()
{
    while (true)
    {
        string userName = "";
        bool isCorrectName;
        do
        {
            Console.Write("Введите имя: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                isCorrectName = false;
                Console.WriteLine("Строка не может быть пустой null!");
                Console.WriteLine("Попробуйте еще раз");
                Console.WriteLine();
                continue;
            }
            else
            {
                isCorrectName = true;
            }

            foreach (char c in userName)
            {
                if (char.IsDigit(c))
                {
                    isCorrectName = false;
                    Console.WriteLine("Имя не может содержать цифры!");
                    Console.WriteLine("Попробуйте еще раз");
                    Console.WriteLine();
                    break;
                }
            }

        } while (isCorrectName == false);

        string userAge = "";
        bool isCorrectAge;
        do
        {
            Console.Write("Введите возраст: ");
            userAge = Console.ReadLine();

            if (!int.TryParse(userAge, out int age))
            {
                isCorrectAge = false;
                Console.WriteLine("Возраст должен содержать только цифры!");
                Console.WriteLine("Попробуйте еще раз");
                Console.WriteLine();
                continue;
            }
            if (age >= 18 && age <= 99)
            {
                isCorrectAge = true;
            }
            else
            {
                isCorrectAge = false;
                Console.WriteLine("Возраст должен быть в диапазоне >= 18 && <= 99");
                Console.WriteLine("Попробуйте еще раз");
                Console.WriteLine();
                continue;
            }
        } while (isCorrectAge == false);

        string secretCode = "";
        bool isCorrectCode;
        do
        {
            Console.Write("Введите секретный код: ");
            secretCode = Console.ReadLine();

            secretCode = secretCode.Trim();
            if (string.IsNullOrWhiteSpace(secretCode))
            {
                isCorrectCode = false;
                Console.WriteLine("Строка не может быть пустой null!");
                Console.WriteLine("Попробуйте еще раз");
                Console.WriteLine();
                continue;
            }
            if (secretCode.Length == 8)
            {
                isCorrectCode = true;
            }
            else
            {
                isCorrectCode = false;
                Console.WriteLine("Секретный код должен состоять из 8 символов!");
                Console.WriteLine("Попробуйте еще раз");
                Console.WriteLine();
                continue;
            }
        } while (isCorrectCode == false);

        Dictionary<string, string> data = new Dictionary<string, string>();

        data.Add("Имя", userName);
        data.Add("Возраст", userAge);
        data.Add("Секретный код", secretCode);
        return data;

    }
}

Dictionary<string, string> data = GetUserDetails();
Console.WriteLine(String.Join(", ", data));
