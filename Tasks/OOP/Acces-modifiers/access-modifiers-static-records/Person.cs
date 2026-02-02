namespace access_modifiers_static_records
{
    // Примеры обычных Record (без параметров, и без валидации в конструкторе)
    public record Person()
    {
        private readonly string? _firstName;
        private readonly string? _lastName;
        private readonly int _age;

        public string? FirstName
        {
            get => _firstName;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(null, nameof(FirstName));

                _firstName = value;
            }
        }
        public string? LastName
        {
            get => _lastName;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(null, nameof(LastName));

                _lastName = value;
            }
        }
        public int Age
        {
            get => _age;
            init
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException(null, nameof(Age));

                _age = value;
            }
        }
    }

    public record Transaction
    {
        private readonly string? _description;
        private readonly decimal _amount;
        private readonly DateTime _date;

        public decimal Amount
        {
            get => _amount;
            init
            {
                if (value < 0)
                    throw new ArgumentException(null, nameof(Amount));

                _amount = value;
            }
        }
        public string? Description
        {
            get => _description;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(null, nameof(Description));

                _description = value;
            }
        }

        public DateTime Date
        {
            get => _date;
            init
            {
                if (value > DateTime.Now || value < DateTime.Today)
                    throw new ArgumentException(null, nameof(Date));

                _date = value;
            }
        }
    }
}
