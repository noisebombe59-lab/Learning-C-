namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part3
{
    public class Drone : Transport, IFlyable
    {
        public Drone(string model, int speed) : base(model, speed) { }

        public override void Move()
        {
            Console.WriteLine($"[Дрон]: [{Model}] активирует пропеллеры");
        }

        public void Fly()
        {
            Console.WriteLine($"[Дрон] парит на высоте 50 метров");
        }
    }
}
