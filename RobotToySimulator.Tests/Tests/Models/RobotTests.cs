using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RobotToySimulator.Models;
using RobotToySimulator.Commands;
using NUnit.Framework.Legacy;

namespace RobotToySimulator.Tests
{
    [TestFixture]
    public class RobotTests
    {

        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot();
        }

        [Test]
        public void Robot_Skip_Move_Before_Placement()
        {
            robot.Move();
            robot.Report(); // Should not output anything
            ClassicAssert.IsFalse(robot.IsPlaced);
        }

        [Test]
        public void Place_Sets_Valid_Position()
        {
            robot.Place(1, 2, Direction.EAST);
            ClassicAssert.IsTrue(robot.IsPlaced);
            ClassicAssert.AreEqual(1, robot.Position.X);
            ClassicAssert.AreEqual(2, robot.Position.Y);
            ClassicAssert.AreEqual(Direction.EAST, robot.Direction);
        }

        // Move - Direction increment 
        [Test]
        public void Move_Update_Position_Correctly()
        {
            robot.Place(0, 0, Direction.NORTH);
            robot.Move();
            ClassicAssert.AreEqual(0, robot.Position.X);
            ClassicAssert.AreEqual(1, robot.Position.Y);
        }
      
        // Move Left Direction 
        [Test]
        public void Left_Rotates_Correctly()
        {
            robot.Place(0, 0, Direction.NORTH);
            robot.Left();
            ClassicAssert.AreEqual(Direction.WEST, robot.Direction);
        }

        // Move Right Direction 
        [Test]
        public void Right_Rotates_Correctly()
        {
            robot.Place(0, 0, Direction.NORTH);
            robot.Right();
            ClassicAssert.AreEqual(Direction.EAST, robot.Direction);
        }
      
    }
}


