namespace access_modifiers_static_records_Part3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var botName = ChatBot.BotName = "X";
                var newBotName = ChatBot.BotName = "X-perl";

                Message message1 = new Message("Mark Twen", "X");
                Message message2 = new Message("Angel Russo", "Спам");
                Message message3 = new Message("Mark Ruffalo", "");

                var filterResult1 = ChatBot.MessageFilter(message1);
                var filterResult2 = ChatBot.MessageFilter(message2);
                var filterResult3 = ChatBot.MessageFilter(message3);

                Console.WriteLine(filterResult1);
                Console.WriteLine(filterResult2);
                Console.WriteLine(filterResult3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}

