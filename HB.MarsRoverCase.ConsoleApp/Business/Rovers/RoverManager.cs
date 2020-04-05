using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Entity;
using HB.MarsRoverCase.ConsoleApp.Helper;
using System.Collections.Generic;

namespace HB.MarsRoverCase.ConsoleApp.Business.Rovers
{
    public class RoverManager : IRoverManager
    {
        public List<Rover> Rovers { get; } = new List<Rover>();

        public ISurface Surface { get; }

        public Rover ActiveRover { get; set; }

        public RoverManager(ISurface surface)
        {
            Surface = surface;
        }

        public void DeployRover(int xCoordinate, int yCoordinate, Direction deployedDirection)
        {
            if (xCoordinate >= 0 && yCoordinate >= 0 && yCoordinate < Surface.Size.Height && xCoordinate < Surface.Size.Width)
            {
                var rover = new Rover(xCoordinate, yCoordinate, deployedDirection, Surface);
                Rovers.Add(rover);
                ActiveRover = rover;
                Logger.WriteLog(this.GetType().Name, $"Rover is deployed successfully. XCoordinate : {xCoordinate} YCoordinate : {yCoordinate} Direction : {rover.Direction:G}");
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"Rover is deployed to out of surface. XCoordinate : {xCoordinate} YCoordinate : {yCoordinate} Direction : {deployedDirection:G}");
            }

        }
    }
}
