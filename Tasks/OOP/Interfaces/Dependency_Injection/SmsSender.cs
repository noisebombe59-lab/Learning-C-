namespace Dependency_Injection
{
    public class SmsSender : ISender
    {
        public void Send(string text)
        {
            Console.WriteLine($"Текст от SmsSender: {text}");
        }
    }
}
