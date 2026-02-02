namespace access_modifiers_static_records_Part3
{
    public static class ChatBot
    {
        private static string? _botName;

        public static string BotName
        {
            get => $"{_botName} [MODERATOR]";
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(BotName));

                if (value.Length < 3)
                    throw new ArgumentException("Длина имени должна быть > 3", nameof(BotName));

                _botName = value;
            }
        }

        public static Message MessageFilter(Message message)
        {
            if (message.Author == null || message.Text == null)
                throw new ArgumentNullException(nameof(message));

            if (message.Text.Contains("Спам"))
                return message with { Text = "[ЗАБЛОКИРОВАНО]" };

            return message;
        }
    }
}
