namespace SISTest
{
    internal class Program
    {
        static SIS.CBSystem Console = new SIS.CBSystem();
        static void Main(string[] args)
        {
            Console.InputStart += Console_InputStart;
            Console.InputDone += Console_InputDone;
            Console.InputStop += Console_InputStop;
            Console.GetInputLineAsync();
        }

        private static void Console_InputStop(object sender, System.EventArgs e)
        {
            Console.WriteLine("Input has stopped.");
        }

        private static void Console_InputDone(object sender, string e)
        {
            Console.WriteLine("You have typed: "+e);
        }

        private static void Console_InputStart(object sender, System.EventArgs e)
        {
            Console.WriteLine("Start Writing.");
        }
    }
}
