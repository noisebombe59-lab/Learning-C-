namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations
{
    public sealed class TaskManager
    {
        const string separator = "-------------------------------------------------";
        private readonly List<BaseTask> _tasks = new List<BaseTask>();

        public void AddTask(BaseTask task)
        {
            ArgumentNullException.ThrowIfNull(task);
            _tasks.Add(task);
        }

        public void ProcessTask()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст");
                Console.WriteLine(separator);
                return;
            }
        }

        public void RunAll()
        {
            foreach (var task in _tasks)
            {
                if (task is INotifiable notification)
                {
                    notification.SendNotification();
                    task.Execute();
                    Console.WriteLine(separator);
                }
                task.Execute();
                Console.WriteLine(separator);
            }
        }
    }
}
