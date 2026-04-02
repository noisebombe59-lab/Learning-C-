namespace LINQ_part3
{
    public record Transactions(DateTime TransactionTime, int TransactionCount, int TransactionId, int CustomerId, decimal TransactionTotalAmount, Operations OperationType, string SpendingCategory);
}
