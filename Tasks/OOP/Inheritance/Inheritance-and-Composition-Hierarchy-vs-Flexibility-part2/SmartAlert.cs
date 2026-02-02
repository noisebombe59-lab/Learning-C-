namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part2
{
    public class SmartAlert
    {
        private readonly Logger _logger;

        public SmartAlert(Logger? logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger), "Передан пустой объект");

            _logger = logger;
        }

        public void Notify(string? message)
        {
            _logger.Log($"СРОЧНО: {message}");
        }
    }
}
