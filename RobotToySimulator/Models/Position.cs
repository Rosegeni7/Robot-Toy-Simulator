using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotToySimulator.Models
{
    public class Position
    {
        public int X { get; set; } 
        public int Y { get; set; } 

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
