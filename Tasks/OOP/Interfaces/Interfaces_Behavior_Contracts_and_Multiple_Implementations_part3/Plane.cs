namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part3
{
    public class Plane : Transport, IFlyable, ICargo
    {
        public Plane(string model, int speed) : base(model, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Самолет]: [{Model}] разгоняется по полосе");
        }

        public void Fly()
        {
            Console.WriteLine("[Самолет] летит в облаках");
        }

        public void DeliverCargo(string destination)
        {
            Console.WriteLine($"[Самолет] доставил ценный груз в: [{destination}]");
        }
    }
}
