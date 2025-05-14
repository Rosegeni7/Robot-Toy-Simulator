using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotToySimulator.Services;

namespace RobotToySimulator.Utils
{
    public class InputHandler
    {
        private readonly CommandProcessor processor;
        public InputHandler (CommandProcessor processor)
        {
            this.processor = processor;
        }

        public void Start ()
        {
            Console.WriteLine("Enter commands (type EXIT to quit) : ");

            while(true)
            {
                string? line = Console.ReadLine ();
                if(line == null || line.Trim().ToUpper() == "EXIT")
                {
                    break;
                }
                processor.Execute (line);
            }

        }

    }
}
