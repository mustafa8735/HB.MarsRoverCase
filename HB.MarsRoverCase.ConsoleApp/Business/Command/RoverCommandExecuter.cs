using HB.MarsRoverCase.ConsoleApp.Business.Rovers;
using HB.MarsRoverCase.ConsoleApp.Entity;
using HB.MarsRoverCase.ConsoleApp.Helper;
using System;

namespace HB.MarsRoverCase.ConsoleApp.Business.Command
{
    public class RoverCommandExecuter : CommandExecuter
    {
        private readonly IRoverManager SquadManager;

        public RoverCommandExecuter(IRoverManager squadManager)
        {
            SquadManager = squadManager;
        }

        public override string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            try
            {
                foreach (var order in command)
                {
                    var movement = (Movement)Enum.Parse(typeof(Movement), order.ToString());
                    SquadManager.ActiveRover.Move(movement);
                }

                retVal = $"{SquadManager.ActiveRover.XCoordinate} {SquadManager.ActiveRover.YCoordinate} {SquadManager.ActiveRover.Direction:G}";
            }
            catch (Exception ex)
            {
                Logger.WriteExceptionLog(this.GetType().Name, ex);
            }

            return retVal;
        }
    }
}
