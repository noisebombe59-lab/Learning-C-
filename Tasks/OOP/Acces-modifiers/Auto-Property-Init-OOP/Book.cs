public class Book
{
    private int _year;

    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; private set; } = true;
    public int Year
    {
        get => _year;
        set
        {
            if (value <= 0) throw new ArgumentException("Год не может быть отрицательным или равен 0");
            _year = value;
        }
    }

    public void Borrow()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine("Книга уже взята");
        }
        else
        {
            Return();
        }
    }

    public void Return()
    {
        Console.WriteLine("Книга возвращена");
        IsAvailable = true;
    }
}