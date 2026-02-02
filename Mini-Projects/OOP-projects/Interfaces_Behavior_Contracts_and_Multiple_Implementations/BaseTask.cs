namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations
{
    public abstract class BaseTask
    {
        public string Title { get; }
        public bool IsCompleted { get; protected set; } = false;

        public BaseTask(string title, bool isCompleted)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            Title = title;
            IsCompleted = isCompleted;
        }

        public abstract void Execute();
    }
}
