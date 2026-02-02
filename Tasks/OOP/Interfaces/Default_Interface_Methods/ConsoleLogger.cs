namespace Default_Interface_Methods
{
    public class ConsoleLogger : ILogger
    {
        public string Message { get; }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
