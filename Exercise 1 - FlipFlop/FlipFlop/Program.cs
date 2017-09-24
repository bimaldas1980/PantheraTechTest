using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop
{
    class Program
    {
        static void Main(string[] args)
        {
            //These parameters can be made configurable to accept different inputs.
            int fromNumber = 1, toNumber = 100, flipNumber = 5, flopNumber = 7;

            if(fromNumber <= 0 || toNumber <= 0 || fromNumber >= toNumber)
            {
                Console.WriteLine("'To' Number should be greater than 'From' number and both numbers should be greater than zero.");
                return;
            }

            if(flipNumber == 0 || flopNumber == 0)
            {
                Console.WriteLine("'Flip' and 'Flop' numbers cannot be zero.");
                return;
            }

            Console.WriteLine("Printing numbers from {0} to {1} where 'Flip' is displayed instead of numbers divisible by {2}, 'Flop' is displayed instead of numbers divisible by {3} and 'Flip Flop' is displayed instead of numbers divisible by both {2} and {3}", fromNumber, toNumber, flipNumber, flopNumber);
        
            var result = Enumerable.Range(fromNumber, toNumber).Select(
                                    i => (i % (flipNumber * flopNumber) == 0) ? "Flip Flop" : 
                                                    (i % flipNumber == 0) ? "Flip" : 
                                                    (i % flopNumber == 0) ? "Flop" : 
                                                    i.ToString()).ToList();

           
            result.ForEach(item => {
                Console.WriteLine(item);
            });
        }
    }
}
