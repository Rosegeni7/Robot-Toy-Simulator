
using System;
using RobotToySimulator.Models;
using RobotToySimulator.Services;
using RobotToySimulator.Utils;

namespace RobotToySimulator
{    
    class Program
    {
        static void Main(string[] args)
        {

            var robot = new Robot();
            var processor = new CommandProcessor (robot);
            var inputhandler = new InputHandler(processor);
            inputhandler.Start();

        }
    }
}
