using HB.MarsRoverCase.ConsoleApp.Entity;

namespace HB.MarsRoverCase.ConsoleApp.Business.Surface
{
    public class Plataeu : ISurface
    {
        public SurfaceSize Size { get; private set; }

        public void DefineSize(int width, int height)
        {
            Size = new SurfaceSize(width, height);
        }
    }
}
