namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part3
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "-------------------------------------------------";

                List<Transport> transports = new List<Transport>();
                Drone drone = new Drone("Mavic Air 3", 70);
                Truck truck = new Truck("Камаз", 130);
                Plane plane = new Plane("Boing-747", 900);

                transports.Add(drone);
                transports.Add(truck);
                transports.Add(plane);

                foreach (var transport in transports)
                {

                    if (transport is IFlyable flyer)
                    {
                        flyer.Fly();
                    }
                    if (transport is ICargo tempCargo)
                    {
                        tempCargo.DeliverCargo("Бали");    
                    }
                    transport.Move();
                    Console.WriteLine(separator);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}