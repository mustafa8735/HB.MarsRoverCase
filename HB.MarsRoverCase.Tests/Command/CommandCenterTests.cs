using HB.MarsRoverCase.ConsoleApp.Business.Command;
using Xunit;

namespace HB.MarsRoverCase.Tests.Command
{
    public class CommandCenterTests
    {
        [Fact]
        public void SendCommandTest()
        {
            var commandCenter = new CommandCenter();
            commandCenter.SendCommand("5 5");
            commandCenter.SendCommand("1 2 N");
            var rover1Result = commandCenter.SendCommand("LMLMLMLMM");
            commandCenter.SendCommand("3 3 E");
            var rover2Result = commandCenter.SendCommand("MMRMMRMRRM");

            Assert.Equal("1 3 N", rover1Result);
            Assert.Equal("5 1 E", rover2Result);
        }       
    }
}
