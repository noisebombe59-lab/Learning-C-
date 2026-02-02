namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part3
{
    public class Truck : Transport, ICargo
    {
        public Truck(string model, int speed) : base(model, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Грузовик]: [{Model}] едет по дороге");
        }

        public void DeliverCargo(string destination)
        {
            Console.WriteLine($"[Грузовик] везет груз в: [{destination}]");
        }
    }
}
