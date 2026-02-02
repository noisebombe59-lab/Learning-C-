namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility
{
    public abstract class BankLogger
    {
        private string? _name;

        protected string? Name { get => _name; }

        protected BankLogger(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Имя не найдено");

            _name = name;
        }

        public void Log(string? message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message), "Объект пуст");
            }

            DoRealWork(message);
        }

        public abstract void DoRealWork(string message);
    }
}