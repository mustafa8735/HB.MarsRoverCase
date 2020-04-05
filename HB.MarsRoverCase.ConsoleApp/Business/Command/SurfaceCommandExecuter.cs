using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Helper;
using System;
using System.Linq;

namespace HB.MarsRoverCase.ConsoleApp.Business.Command
{
    public class SurfaceCommandExecuter : CommandExecuter
    {
        private ISurface Surface;
        public SurfaceCommandExecuter(ISurface surface)
        {
            Surface = surface;
        }

        public override string ExecuteCommand(string command)
        {
            var retVal = string.Empty;

            try
            {
                var splitCommand = command.Split(' ');

                if (splitCommand.Count() == 2)
                {
                    var surfaceWidth = int.Parse(splitCommand[0]) + 1; //En son nokyata gidebilmesi için bir artırıyoruz
                    var surfaceHeight = int.Parse(splitCommand[1]) + 1;//En son nokyata gidebilmesi için bir artırıyoruz

                    if(surfaceWidth > 0 && surfaceHeight > 0)
                    {
                        Surface.DefineSize(surfaceWidth, surfaceHeight);
                        Logger.WriteLog(this.GetType().Name, "Surface is defined successfully");
                    }
                    else
                    {
                        Logger.WriteLog(this.GetType().Name, $"Surface widh or height smaller than zero. SurfaceWidth : {surfaceWidth-1} SurfaceHeight : {surfaceHeight - 1}");
                    }
                    
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, $"Surface define command is invalid. Command : {command}");
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