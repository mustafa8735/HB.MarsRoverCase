using HB.MarsRoverCase.ConsoleApp.Business.Command;

namespace HB.MarsRoverCase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandCenter = new CommandCenter();
            WriteMessageToConsole(commandCenter.SendCommand("5 5"));
            WriteMessageToConsole(commandCenter.SendCommand("1 2 N"));
            WriteMessageToConsole(commandCenter.SendCommand("LMLMLMLMM"));
            WriteMessageToConsole(commandCenter.SendCommand("3 3 E"));
            WriteMessageToConsole(commandCenter.SendCommand("MMRMMRMRRM"));

            System.Console.ReadKey();
        }

        private static void WriteMessageToConsole(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                System.Console.WriteLine(message);
            }
        }
    }
}
