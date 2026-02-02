namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part3
{
    public class Book : Media
    {
        public string Author { get; init; }

        public Book(string author, string title) : base(title)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException(nameof(author), "Имя автора обязательно!");

            Author = author;
        }
    }
}
