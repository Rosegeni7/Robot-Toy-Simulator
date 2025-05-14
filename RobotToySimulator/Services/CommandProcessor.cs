using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RobotToySimulator.Commands;
using RobotToySimulator.Models;
using ICommand = RobotToySimulator.Commands.ICommand;

namespace RobotToySimulator.Services
{
    public class CommandProcessor
    {
        private readonly Robot robot;
        public CommandProcessor(Robot robot)
        {
            this.robot = robot;
        }

        public ICommand? Parse(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return null;

            var tokens = input.Trim().Split(' ');
            var command = tokens[0].ToUpper();

            switch (command)
            {
                case "PLACE":
                    if (tokens.Length == 2)
                    {
                        var args = tokens[1].Split(',');
                        if (args.Length == 3 &&
                            int.TryParse(args[0], out int x) &&
                            int.TryParse(args[1], out int y) &&
                            Enum.TryParse(args[2], true, out Direction dir))
                        {
                            return new PlaceCommand(x, y, dir);
                        }
                    }
                    break;

                case "MOVE": return new MoveCommand();                       
                case "LEFT": return new LeftCommand(); 
                case "RIGHT": return new RightCommand();                       
                case "REPORT": return new ReportCommand();            

            }
            return null;
        }

        public void Execute(string input)
        {
            var cmd = Parse(input);
            cmd?.Execute(robot);
        }
    }
}
