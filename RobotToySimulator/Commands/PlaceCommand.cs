using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotToySimulator.Models;

namespace RobotToySimulator.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly int x, y;
        private readonly Direction direction;

        public PlaceCommand(int x, int y, Direction direction)
        {
            this.x = 0;
            this.y = 0;
            this.direction = direction;
        }
       public void Execute(Robot robot)
        {
            robot.Place(x,y, direction);
        }
    }
}
