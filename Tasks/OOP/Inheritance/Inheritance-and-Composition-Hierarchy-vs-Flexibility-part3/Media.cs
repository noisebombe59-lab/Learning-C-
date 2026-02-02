namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part3
{
    public class Media
    {
        public string Title { get; init; }

        public Media(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title), "Название обязательно!");

            Title = title;
        }
    }
}
