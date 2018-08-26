namespace SimpleTwitterApp.UI.Services
{
    public interface ILogService
    {
        void Log(string message);
    }

    public class LogService : ILogService
    {
        public void Log(string message)
        {
            // log the message
        }
    }
}