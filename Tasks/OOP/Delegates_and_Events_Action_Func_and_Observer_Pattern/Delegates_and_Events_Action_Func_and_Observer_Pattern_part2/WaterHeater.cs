namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part2
{
    public class WaterHeater
    {
        public event Action? BoillingFinished;

        public void StartHeating()
        {
            if (BoillingFinished == null)
            {
                Console.WriteLine("Объект событий пуст");
                return;
            }
            else
            {
                Console.WriteLine($"Вода греется...");
                BoillingFinished?.Invoke();
            }
        }
    }
}
