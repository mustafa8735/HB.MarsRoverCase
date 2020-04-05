using HB.MarsRoverCase.ConsoleApp.Business.Surface;
using HB.MarsRoverCase.ConsoleApp.Entity;
using HB.MarsRoverCase.ConsoleApp.Helper;

namespace HB.MarsRoverCase.ConsoleApp.Business.Rovers
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }
        public ISurface Surface { get; }

        public Rover(int xCoordinate, int yCoordinate, Direction direction, ISurface surface)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = direction;
            Surface = surface;
        }

        public void Move(Movement movement)
        {
            if (movement == Movement.L)
            {
                TurnLeft();
            }
            else if (movement == Movement.R)
            {
                TurnRight();
            }
            else if (movement == Movement.M)
            {
                MoveForward();
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"Rover move command is invalid. Command : {movement:G}");
            }
        }

        private void MoveForward()
        {
            if (Direction == Direction.N)
            {
                if (YCoordinate + 1 <= Surface.Size.Height)
                {
                    YCoordinate++;
                    Logger.WriteLog(this.GetType().Name, "Rover is moved to North");
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, "Direction is bigger than surface size");
                }
            }
            else if (Direction == Direction.E)
            {
                if (XCoordinate + 1 <= Surface.Size.Width)
                {
                    XCoordinate++;
                    Logger.WriteLog(this.GetType().Name, "Rover is moved to East");
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, "Direction is bigger than surface size");
                }

            }
            else if (Direction == Direction.S)
            {
                if (YCoordinate - 1 >= 0)
                {
                    YCoordinate--;
                    Logger.WriteLog(this.GetType().Name, "Rover is moved to South");
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, "Direction is bigger than surface size");
                }
            }
            else if (Direction == Direction.W)
            {
                if (XCoordinate - 1 >= 0)
                {
                    XCoordinate--;
                    Logger.WriteLog(this.GetType().Name, "Rover is moved to West");
                }
                else
                {
                    Logger.WriteLog(this.GetType().Name, "Direction is bigger than surface size");
                }
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"Rover move command is invalid. Command : {Direction:G}");
            }

        }


        /* TO DO : Eğer yön Norht ise Sola döndüğünde yön yine North olmaz. Düşünmeliyiz 
         * -- Sağa dönüş içinde geçerli
         * */
        private void TurnLeft()
        {
            var retVal = string.Empty;

            if (Direction == Direction.N)
            {
                Direction = Direction.W;
                Logger.WriteLog(this.GetType().Name, "Rover is turned left to North");
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.S;
                Logger.WriteLog(this.GetType().Name, "Rover is turned left to West");
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.E;
                Logger.WriteLog(this.GetType().Name, "Rover is turned left to South");
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.N;
                Logger.WriteLog(this.GetType().Name, "Rover is turned left to East");
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"Rover move Turn Left  command is invalid. Command : {Direction:G}");
            }
        }

        private void TurnRight()
        {
            if (Direction == Direction.N)
            {
                Direction = Direction.E;
                Logger.WriteLog(this.GetType().Name, "Rover is turned right to North");
            }
            else if (Direction == Direction.W)
            {
                Direction = Direction.N;
                Logger.WriteLog(this.GetType().Name, "Rover is turned right to West");
            }
            else if (Direction == Direction.S)
            {
                Direction = Direction.W;
                Logger.WriteLog(this.GetType().Name, "Rover is turned right to South");
            }
            else if (Direction == Direction.E)
            {
                Direction = Direction.S;
                Logger.WriteLog(this.GetType().Name, "Rover is turned right to East");
            }
            else
            {
                Logger.WriteLog(this.GetType().Name, $"Rover move Turn Right  command is invalid. Command : {Direction:G}");
            }

        }

    }
}
