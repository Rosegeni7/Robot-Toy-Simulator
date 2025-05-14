using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotToySimulator.Models;

namespace RobotToySimulator.Commands
{
    public class RightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.Right();
        }
    }
}
