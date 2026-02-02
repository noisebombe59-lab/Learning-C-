namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility
{
    public class LogEntry
    {
        public DateTime TimeStamp { get; init; }
        public string Level { get; init; }
        public string Message { get; init; }

        public LogEntry(DateTime timeStamp, string level, string message)
        {
            if (timeStamp > DateTime.Now)
                throw new ArgumentException("Операция не может быть в будущем");

            if (DateTime.Now - timeStamp > TimeSpan.FromDays(30))
                throw new ArgumentException("Операция проводилась более 30 дней назад", nameof(timeStamp));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Установите уровень", nameof(level));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Сообщение должно содержать текст", nameof(message));

            TimeStamp = timeStamp;
            Level = level;
            Message = message;
        }
    }
}
