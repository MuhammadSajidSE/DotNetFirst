namespace college_Application.MyLooging
{
    public class LogToDb : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("I am LOG to DB class");

        }
    }
}
