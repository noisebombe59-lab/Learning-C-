namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations
{
    public class SimpleTask : BaseTask
    {
        public SimpleTask(string title, bool isCompleted) : base(title, isCompleted) { }
        
        public override void Execute()
        {
            IsCompleted = true;
            Console.WriteLine($"Задача: {Title} выполнена");
        }
    }
}
