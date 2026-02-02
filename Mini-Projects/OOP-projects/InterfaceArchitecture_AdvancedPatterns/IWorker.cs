namespace InterfaceArchitecture_AdvancedPatterns
{
    public interface IWorker : IEmployee
    {
        void TakeTask(string taskName);
    }
}
