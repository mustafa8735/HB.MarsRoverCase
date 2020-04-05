using HB.MarsRoverCase.ConsoleApp.Business.Rovers;
using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Entity;
using System;
using System.Linq;
using Xunit;

namespace HB.MarsRoverCase.Tests.Rovers
{
    public class RoverTests
    {
       
        [Theory]
        [InlineData("4 2 N",1,1)]
        [InlineData("4 2 N", 6, 6)]
        public void RoverDeploy(string command,int plataueWidth,int plataueHeight)
        {
            var plataue = new Plataeu();
            plataue.DefineSize(plataueWidth, plataueHeight);

            IRoverManager manager = new RoverManager(plataue);
            var commandSplit = command.Split(' ');
            var expectedXCoordinate = int.Parse(commandSplit[0]);
            var expectedYCoordinate = int.Parse(commandSplit[1]);
            var expectedDirection = (Direction)Enum.Parse(typeof(Direction), commandSplit[2]);

            manager.DeployRover(expectedXCoordinate, expectedYCoordinate, expectedDirection);

        }

        [Theory]
        [InlineData("MRRL")]
        [InlineData("MMLR")]
        [InlineData("LMLMLMLMM")]
        public void RoverMove(string command)
        {
            var plataue = new Plataeu();
            plataue.DefineSize(5, 5);
            IRoverManager roverManager = new RoverManager(plataue);
            roverManager.DeployRover(0, 0, Direction.N);

            foreach (var moveCommand in command.ToCharArray())
            {
                var movement = (Movement)Enum.Parse(typeof(Movement), moveCommand.ToString());
                roverManager.ActiveRover.Move(movement);
            }          

            Assert.Equal(0, roverManager.ActiveRover.XCoordinate);
            Assert.Equal(Direction.N,roverManager.ActiveRover.Direction);
            Assert.Equal(2, roverManager.ActiveRover.YCoordinate);
        }
    }
}
