namespace InterfaceArchitecture_AdvancedPatterns
{
    public class Manager : IEmployee, ILeader
    {
        public string Name { get; }
        public decimal ManagerSalary { get; private set; }

        public Manager(decimal managerSalary, string name)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(managerSalary);

            ManagerSalary = managerSalary;
            Name = name;
        }

        public void CalculateSalary()
        {
            Console.WriteLine($"Зарплата менеджера {Name}: {ManagerSalary}");
        }

        void ILeader.GiveTask(IWorker worker, string taskName)
        {
            Console.WriteLine($"[Менеджер] - {Name} делегировал задачу '{taskName}' сотруднику: {worker.Name}");

            worker.TakeTask(taskName);
        }
    }
}

