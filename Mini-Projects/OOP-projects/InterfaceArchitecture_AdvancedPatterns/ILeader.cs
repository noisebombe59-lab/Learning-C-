namespace InterfaceArchitecture_AdvancedPatterns
{
    public interface ILeader
    {
        void GiveTask(IWorker worker, string taskName);
    }
}
