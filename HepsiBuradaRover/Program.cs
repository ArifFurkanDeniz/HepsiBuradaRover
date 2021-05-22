using HepsiBuradaModel;
using System;
using System.Text.RegularExpressions;

namespace HepsiBuradaRover
{
    class Program
    {
        static string upperRight;
        static int edgeX, edgeY;
        readonly static int roverCount = 2;
        static IRover[] roverList = new Rover[roverCount];
        static void Main(string[] args)
        {
            GetInputs();

            foreach (var rover in roverList)
            {
                rover.CalculatePoint(edgeX, edgeY);
            }   
        }
           
        private static void GetInputs()
        {
            upperRight = Console.ReadLine().ToUpper();
            while (true)
            {
                Regex regex = new Regex(@"^\d\d$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(upperRight))
                    break;
                else
                {
                    Console.WriteLine("Wrong input! example: 55");
                }
                upperRight = Console.ReadLine().ToUpper();
            }

            edgeX = Convert.ToInt16(upperRight[0].ToString());
            edgeY = Convert.ToInt16(upperRight[1].ToString());


            for (int i = 0; i < roverCount; i++)
            {
                var position = Console.ReadLine().ToUpper();
                while (true)
                {
                    Regex regex = new Regex(@"^\d\d[NWSE]$", RegexOptions.IgnoreCase);
                    if (regex.IsMatch(position))
                        break;
                    else
                    {
                        Console.WriteLine("Wrong input! example: 12N");
                    }
                    position = Console.ReadLine().ToUpper();
                }

                var movement = Console.ReadLine().ToUpper();
                while (true)
                {
                    Regex regex = new Regex(@"^[LRM]*$", RegexOptions.IgnoreCase);
                    if (regex.IsMatch(movement))
                        break;
                    else
                    {
                        Console.WriteLine("Wrong input! example: LMLMLMLMM");
                    }
                    movement = Console.ReadLine().ToUpper();
                }

                roverList[i] = new Rover(position, movement);
            }
        }
    }
}
