namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations
{
    public class UrgentTask : SimpleTask, INotifiable
    {
        public UrgentTask(string title, bool isCompleted) : base(title, isCompleted) { }

        public void SendNotification()
        {
            Console.WriteLine($"Внимание! Срочная задача: \"{Title}\"");
        }

        public override void Execute()
        {
            Console.WriteLine($"Критическая задача: \"{Title}\" завершена");
            IsCompleted = true;
        }
    }
}
