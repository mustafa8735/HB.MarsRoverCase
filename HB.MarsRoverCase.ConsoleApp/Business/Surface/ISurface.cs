using HB.MarsRoverCase.ConsoleApp.Entity;

namespace HB.MarsRoverCase.ConsoleApp.Business.Surface
{
    public interface ISurface
    {
        SurfaceSize Size { get; }

        void DefineSize(int width, int height);
    }
}
