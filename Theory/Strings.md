─────────────────────────────────────────────────────────────────────
Что такое string и StringBuilder

string — неизменяемый (immutable) тип.
Каждая модификация (+, +=, Replace, Substring и т.д.) создаёт новую строку в памяти.

StringBuilder — изменяемый (mutable) тип.
Меняет содержимое на месте — почти без лишних аллокаций.

Пример кода
string a = "hello";
a += " world"; // создаётся НОВАЯ строка!

var sb = new StringBuilder();
sb.Append("hello");
sb.Append(" world"); // меняет существующий буфер
──────────────────────────────────────────────────────────────────────
Когда что использовать

string — используй:
• 1–5 простых конкатенаций
• Константы, имена, URL, токены
• Когда нужна иммутабельность и потокобезопасность
StringBuilder — используй:
• В циклах с += или множественными модификациями
• Сборка больших текстов (логи, HTML, CSV)
• >10 операций над одной строкой
──────────────────────────────────────────────────────────────────────
Основные методы string

str.Length
str.Substring(5) / str.Substring(5, 10)
str.IndexOf("text")               // -1 если нет
str.Contains("word")              // .NET 5+
str.StartsWith("http") / str.EndsWith(".json")
str.Replace("old", "new")         // новая строка!
str.ToLower() / str.ToUpper()
str.Trim() / str.TrimStart() / str.TrimEnd()
str.Split(';')

string.Join(", ", array)          // массив → строка
string.IsNullOrEmpty(str)
string.IsNullOrWhiteSpace(str)    // лучший метод для проверки пустоты
──────────────────────────────────────────────────────────────────────
Основные методы StringBuilder

var sb = new StringBuilder();                 // пустой
var sb = new StringBuilder(10_000);           // с начальной ёмкостью!

sb.Append("text");                            // + много перегрузок
sb.AppendLine("строка с переводом строки");
sb.AppendLine();                              // просто \r\n

sb.Insert(0, "ПРЕФИКС: ");
sb.Remove(10, 5);                             // удалить 5 символов с позиции 10
sb.Replace("old", "new");                     // во всём буфере

sb.Clear();                                   // .NET Core 2.1+ (обнуляет)
sb.Length = 0;                                // альтернатива

string result = sb.ToString();                // ТОЛЬКО В КОНЦЕ!
──────────────────────────────────────────────────────────────────────
Классический пример (плохо vs хорошо)

// ПЛОХО — в цикле += string
string log = "";
for (int i = 0; i < 10_000; i++)
{
    log += $"действие {i}\n"; // тысячи аллокаций!
}

// ХОРОШО — StringBuilder
var sb = new StringBuilder(1_000_000); // сразу большая ёмкость
for (int i = 0; i < 10_000; i++)
{
    sb.Append("действие ").Append(i).AppendLine();
}
string finalLog = sb.ToString();
──────────────────────────────────────────────────────────────────────
Важные правила

• В цикле += string — сразу плохо (много мусора и медленно).
• ToString() у StringBuilder вызывай только один раз в конце.
• Всегда используй string.IsNullOrWhiteSpace() для проверки ввода.
• Если знаешь примерный размер — задавай capacity в конструкторе StringBuilder.
• string.Join, string.Concat, string.Format под капотом часто используют StringBuilder.
──────────────────────────────────────────────────────────────────────