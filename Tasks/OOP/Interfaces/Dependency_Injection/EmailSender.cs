namespace Dependency_Injection
{
    public class EmailSender : ISender
    {
        public void Send(string text)
        {
            Console.WriteLine($"Текст от EmailSender: {text}");
        }
    }
}
