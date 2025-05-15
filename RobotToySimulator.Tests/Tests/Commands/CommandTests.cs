using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using RobotToySimulator.Commands;
using RobotToySimulator.Models;
using NUnit.Framework.Legacy;

namespace RobotToySimulator.Tests
{
    [TestFixture]
    public class CommandTests
    {
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot();
        }

        [Test]
        public void PlaceCommand_Places_Correctly()
        {
            var cmd = new PlaceCommand(1, 2, Direction.SOUTH);
            cmd.Execute(robot);
            ClassicAssert.IsTrue(robot.IsPlaced);
            ClassicAssert.AreEqual(0, robot.Position.X);
            ClassicAssert.AreEqual(0, robot.Position.Y);
            ClassicAssert.AreEqual(Direction.SOUTH, robot.Direction);
        }       

        [Test]
        public void MoveCommand_Moves_Robot()
        {
            var place = new PlaceCommand(0, 0, Direction.EAST);
            place.Execute(robot);

            var move = new MoveCommand();
            move.Execute(robot);           

            ClassicAssert.AreEqual(1, robot.Position.X);
            ClassicAssert.AreEqual(0, robot.Position.Y);
        }

        [Test]
        public void LeftCommand_Turns_Left()
        {
            var place = new PlaceCommand(0, 0, Direction.NORTH);
            place.Execute(robot);

            var left = new LeftCommand();
            left.Execute(robot);

            ClassicAssert.AreEqual(Direction.WEST, robot.Direction);
        }

        [Test]
        public void RightCommand_Turns_Right()
        {
            var place = new PlaceCommand(0, 0, Direction.NORTH);
            place.Execute(robot);

            var right = new RightCommand();
            right.Execute(robot);

            ClassicAssert.AreEqual(Direction.EAST, robot.Direction);
        }

        [Test]
        public void ReportCommand_Prints_Correct_Output()
        {
            var place = new PlaceCommand(2, 3, Direction.WEST);
            place.Execute(robot);

            var writer = new StringWriter();
            Console.SetOut(writer);

            var report = new ReportCommand();
            report.Execute(robot);

            var output = writer.ToString().Trim();
            ClassicAssert.AreEqual("Output is 0,0,WEST", output);
        }
    }
}
