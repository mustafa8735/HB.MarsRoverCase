using HB.MarsRoverCase.ConsoleApp.Business.Rovers;
using HB.MarsRoverCase.ConsoleApp.Entity;
using HB.MarsRoverCase.ConsoleApp.Helper;
using System;
using System.Linq;

namespace HB.MarsRoverCase.ConsoleApp.Business.Command
{
    public class RoverDeployCommandExecuter : CommandExecuter
    {
        private readonly IRoverManager RoverManager;

        public RoverDeployCommandExecuter(IRoverManager roverManager)
        {
            RoverManager = roverManager;
        }


        /* Split with space
         * First is XCoordinate
         * Second is YCoordinate
         * Third is direction */
        public override string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            try
            {
                var splitCommand = command.Split(' ');

                if (splitCommand.Count() == 3)
                {
                    var xCoordinate = int.Parse(splitCommand[0]);
                    var yCoordinate = int.Parse(splitCommand[1]);
                    var direction = (Direction)Enum.Parse(typeof(Direction), splitCommand[2]);

                    RoverManager.DeployRover(xCoordinate, yCoordinate, direction);//Loglama yapılmadı.DeployRover içinde loglama mevcut. 
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, $"Rover deploymnet command is invalid. Command : {command}");
                }

            }
            catch (Exception ex)
            {
                Logger.WriteExceptionLog(this.GetType().Name, ex);
            }

            return retVal;
        }


    }
}
