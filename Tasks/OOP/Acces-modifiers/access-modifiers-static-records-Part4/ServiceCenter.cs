namespace access_modifiers_static_records_Part4
{
    public static class ServiceCenter
    {
        private static int _partsStock = 2;

        public static int PartsStock { get => _partsStock; }

        public static Smartphone Repair(Smartphone smartphone)
        {
            if (smartphone.IsFixed == true)
                return smartphone;

            if (PartsStock > 0)
            {
                _partsStock--;

                Console.WriteLine($"Смартфон: {smartphone.Model} успешно отремотирован");

                return smartphone with { IsFixed = true };
            }

            Console.WriteLine($"Для {smartphone.Model} запчастей нет");
            return smartphone;
        }
    }
}
