namespace LINQ_part3
{
    public record Customer(string CustomerFullName, int CustomerAge, int CustomerId, decimal MoneyAmount, string CustomerStatus = "Обычный");
}
