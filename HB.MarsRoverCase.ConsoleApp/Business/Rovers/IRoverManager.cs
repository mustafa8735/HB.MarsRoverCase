using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Entity;
using System.Collections.Generic;

namespace HB.MarsRoverCase.ConsoleApp.Business.Rovers
{
    public interface IRoverManager
    {
        List<Rover> Rovers { get; }

        Rover ActiveRover { get; }

        ISurface Surface { get; }

        void DeployRover(int x, int y, Direction direction);
    }
}
