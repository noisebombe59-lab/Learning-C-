namespace Book_Library
{
    public class Book
    {
        public bool IsAvailable { get; private set; } = true;
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public int Year { get; private set; }

        public Book(string title, string author, int year)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Название обязательно!");
            Title = title.Trim();

            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Имя автора обязательно!");
            Author = author.Trim();

            if (year <= 0) throw new ArgumentException("Год должен быть положительным числом");
            Year = year;
        }

        public void SetAvailability(bool status)
        {
            IsAvailable = status;
        }
    }
}
