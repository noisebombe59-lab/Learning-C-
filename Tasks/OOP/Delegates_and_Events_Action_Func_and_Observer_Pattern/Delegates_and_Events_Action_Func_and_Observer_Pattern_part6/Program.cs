namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part6
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var kitchenSensor = new MotionSensor();
                var hallwaySensor = new MotionSensor();

                kitchenSensor.SensorTriggered += UniversalHandler;
                hallwaySensor.SensorTriggered += UniversalHandler;

                kitchenSensor.Detect("Спальня");
                hallwaySensor.Detect("кухня");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static void UniversalHandler(object? sender, MotionEventArgs e)
        {
            if (sender == null)
            {
                Console.WriteLine($"Нет данных");
                return;
            }
            if (sender is MotionSensor sensor)
            {
                Console.WriteLine($"Датчик сработал! Локация: {e.Location}, Хэш-код датчика: {sender.GetHashCode()}");
            }
        }
    }
}