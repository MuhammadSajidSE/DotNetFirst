namespace college_Application.MyLooging
{
    public class LogToServer : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("I am LOG to Server class");

        }
    }
}
