using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string area = Console.ReadLine().Trim();
            string startingPosition = Console.ReadLine().Trim().ToUpper();
            string movies = Console.ReadLine().Trim().ToUpper();

            Position position = new Position(area, startingPosition, movies);
            try
            {
                position.StartMoving();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
