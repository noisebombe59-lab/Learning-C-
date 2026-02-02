namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part4
{
    public class Employee : IRelaxable, IWorkable
    {
        void IWorkable.DoWork()
        {
            Console.WriteLine("Сотрудник работает");
        }

        void IRelaxable.DoWork()
        {
            Console.WriteLine("Сотрудник отдыхает");
        }
    }
}
