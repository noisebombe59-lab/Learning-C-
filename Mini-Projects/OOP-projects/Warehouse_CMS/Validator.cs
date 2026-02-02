namespace Warehouse_CMS
{
    public static class Validator
    {
        public static string IsValidName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым или состоять из пробелов", nameof(name));

            return name;
        }

        public static string IsValidCategory(string? category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Категория не может быть пустым или состоять из пробелов", nameof(category));

            return category;
        }
        public static decimal IsValidPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Значение цены не может быть отрицательным", nameof(price));

            return price;
        }

        public static int IsValidQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Количество не может быть отрицательным", nameof(quantity));

            return quantity;
        }
    }
}
