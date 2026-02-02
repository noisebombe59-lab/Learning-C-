namespace Default_Interface_Methods
{
    public interface ILogger
    {
        void WriteMessage(string message);
        void WriteError(string error) => WriteMessage($"[Error]: {error}");
    }
}
