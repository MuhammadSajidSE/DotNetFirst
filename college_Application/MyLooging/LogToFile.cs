namespace college_Application.MyLooging
{
    public class LogToFile : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("I am LOG to File class");

        }
    }
}
