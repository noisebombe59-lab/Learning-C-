namespace access_modifiers_static_records_Part2
{
    public static class SecuritySystem
    {
        private static int _totalEntries;

        public static int TotalEntries
        {
            get => _totalEntries;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Количество человек не может быть отрицательным");
                }
                _totalEntries = value;
            }
        }

        public static bool CanAccess(Pass pass, int doorLevel)
        {
            if (pass.Level >= doorLevel && pass.ExpiryDate > DateTime.Now)
            {
                TotalEntries++;
                return true;
            }

            return false;
        }

        public static void ShowStats()
        {
            Console.WriteLine($"Количество вошедших людей: {TotalEntries}");
        }
    }
}
