using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotToySimulator.Models
{
    public class Robot
    {
        private const int TableSize = 5; // 5 * 5
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsPlaced { get; private set; }

        public void Place(int x, int y, Direction direction)
        {
            if (IsValidPosition(x, y))
            {
                Position = new Position(x,y);
                Direction = direction;
                IsPlaced = true;
            }
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < TableSize && y >= 0 && y < TableSize;
        }

        // Increment based on movement
        public void Move()
        {
            if (!IsPlaced) return;

            var newposition = Position;

            switch (Direction)
            {
                case Direction.NORTH:
                    newposition.Y++;
                    break;
                case Direction.EAST:
                    newposition.X++;
                    break;
                case Direction.SOUTH:
                    newposition.Y--;
                    break;
                case Direction.WEST:
                    newposition.X--;
                    break;
            }

            if (IsValidPosition(newposition.X, newposition.Y))
            {
                Position= newposition;
            }
        }

        // Move to left from 90 degree angle
        // Directions Enum represent NORTH = 0, EAST = 1 (Right), SOUTH = 2, WEST = 3 (Left)
        public void Left()
        {
            if (!IsPlaced) return;
            Direction = (Direction)(((int)Direction + 3) % 4); // from East >> (1+3)%4 =0 = North
        }

        // Move to right from 90 degree angle 
        // Directions Enum represent NORTH = 0, EAST = 1 (Right), SOUTH = 2, WEST = 3 (Left)
        public void Right()
        {
            if (!IsPlaced) return;
            Direction = (Direction)(((int)Direction + 1) % 4); // from East >> (1+1)%4 =2 = South 
        }

        // Report or Display the output
        public void Report()
        {
            if (!IsPlaced) return;
            Console.WriteLine($"Output is {Position.X},{Position.Y},{Direction}");
        }


    }
}
