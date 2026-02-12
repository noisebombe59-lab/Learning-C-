namespace Delegates_and_Events_Action_Func_and_Observer_Pattern
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var separator = "-------------------------------------------------------------------------";
                var pricePerKw = 0.5;
                var isSecurityArmed = true;
                var energyCalculate = (int amountRooms) => amountRooms * 1.5 * pricePerKw;
                var smartHub = new SmartHub();
                var activeRoomsCount = 0;

                smartHub.EnergyCalculator = energyCalculate;

                smartHub.RoomFilter = stopWord => stopWord != "Подвал";

                smartHub.Logger = message => Console.WriteLine($"[LOG] >> {message}");

                smartHub.MotionStatusChanged += (sender, e) =>
                {
                    Console.WriteLine(separator);
                    if (e.IsDetected)
                    {
                        Console.WriteLine($"[СВЕТ] В комнате '{e.RoomName}' включен свет");
                        Console.WriteLine(separator);
                        activeRoomsCount++;
                    }
                    else
                    {
                        activeRoomsCount--;
                    }
                };

                smartHub.MotionStatusChanged += (sender, e) =>
                {
                    if (e.IsDetected && isSecurityArmed)
                        Console.WriteLine($"[ОХРАНА] !!! ТРЕВОГА в '{e.RoomName}'!!!");
                    Console.WriteLine(separator);
                };

                smartHub.MotionStatusChanged += (sender, e) =>
                {
                    string status = e.IsDetected ? "активный режим" : "экономия энергий";
                    Console.WriteLine($"[Климат] Кондей в '{e.RoomName}' перешел в {status} режим");
                    Console.WriteLine(separator);
                };

                smartHub.DetectMotion("Гостиная", true);
                Console.WriteLine(separator);

                smartHub.DetectMotion("Подвал", true);
                Console.WriteLine(separator);

                smartHub.PrintReport(activeRoomsCount);
                Console.WriteLine(separator);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}