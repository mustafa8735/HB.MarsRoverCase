using HB.MarsRoverCase.ConsoleApp.Business.Rovers;
using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Helper;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HB.MarsRoverCase.ConsoleApp.Business.Command
{
    public class CommandCenter
    {
        public ISurface surface;
        public IRoverManager roverManager;

        public CommandCenter()
        {
            surface = new Plataeu();
            roverManager = new RoverManager(surface);
        }

        private Dictionary<Regex, CommandExecuter> CommandExecuterDictionary => new Dictionary<Regex, CommandExecuter>()
        {
            {new Regex("^\\d+ \\d+$"),new SurfaceCommandExecuter(surface) },
            {new Regex("^[LMR]+$"),new RoverCommandExecuter(roverManager) },
            {new Regex("^^\\d+ \\d+ [NSWE]$"),new RoverDeployCommandExecuter(roverManager) }
        };


        public string SendCommand(string command)
        {
            var retVal = string.Empty;

            var commandExecuter = GetCommandExecuter(command);

            if (commandExecuter != null)
            {
                retVal = commandExecuter.ExecuteCommand(command);
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"CommandExecuter could not found. Command : {command}");
            }

            return retVal;
        }

        private CommandExecuter GetCommandExecuter(string command)
        {
            CommandExecuter retVal = null;

            foreach (var commandExecuter in CommandExecuterDictionary)
            {
                if (commandExecuter.Key.IsMatch(command))
                {
                    retVal = commandExecuter.Value;
                    break;
                }
            }

            return retVal;
        }

    }
}
