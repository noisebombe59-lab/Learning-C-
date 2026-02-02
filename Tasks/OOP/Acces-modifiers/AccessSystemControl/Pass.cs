namespace AccessSystemControl
{
    public record Pass(string? OwnerName, int Level, DateTime ExpiryDate);
}
