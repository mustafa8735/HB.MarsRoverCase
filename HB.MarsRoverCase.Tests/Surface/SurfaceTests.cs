using HB.MarsRoverCase.ConsoleApp.Business.Command;
using Xunit;

namespace HB.MarsRoverCase.Tests.Surface
{
    public class SurfaceTests
    {
        [Theory]
        [InlineData("0 1")]
        [InlineData("2 7")]
        [InlineData("9 1")]
        [InlineData("8 8")]
        [InlineData("-1 -1")]
        public void CreateSurfaceWithCommand(string command)
        {
            var commandSplit = command.Split(' ');
            var expectedWidth = int.Parse(commandSplit[0]) + 1;
            var expectedHeight = int.Parse(commandSplit[1]) + 1;

            var commandCenter = new CommandCenter();
            commandCenter.SendCommand(command);

            Assert.Equal(expectedWidth,commandCenter.surface.Size.Width);
            Assert.Equal(expectedHeight, commandCenter.surface.Size.Height);
        }
    }
}
