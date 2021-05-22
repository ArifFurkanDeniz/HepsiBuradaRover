using System;
using System.Text.RegularExpressions;

namespace HepsiBuradaRover
{
    class Program
    {
        static string upperRight, rover1Position, rover1Movement,rover2Position, rover2Movement;
        static int rover1X, rover1Y, rover2X, rover2Y, edgeX, edgeY;
        static void Main(string[] args)
        {
            GetInputs();
            CalculatePoint(rover1Position[2], rover1Movement, rover1X, rover1Y);
            CalculatePoint(rover2Position[2], rover2Movement, rover2X, rover2Y);
        
        }

        private static void CalculatePoint(char currentRotation, string roverMovement, int roverX, int roverY)
        {
            foreach (var item in roverMovement)
            {
                if (currentRotation == 'N')
                {
                    switch (item)
                    {
                        case 'M': if (edgeY >= roverY + 1) roverY++; break;
                        case 'L': currentRotation = 'W'; break;
                        case 'R': currentRotation = 'E'; break;
                        default:
                            break;
                    }
                }
                else if (currentRotation == 'S')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= roverY - 1) roverY--; break;
                        case 'L': currentRotation = 'E'; break;
                        case 'R': currentRotation = 'W'; break;
                        default:
                            break;
                    }
                }
                else if (currentRotation == 'W')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= roverX - 1) roverX--; break;
                        case 'L': currentRotation = 'S'; break;
                        case 'R': currentRotation = 'N'; break;
                        default:
                            break;
                    }
                }
                else if (currentRotation == 'E')
                {
                    switch (item)
                    {
                        case 'M': if (edgeX >= roverX + 1)  roverX++; break;
                        case 'L': currentRotation = 'N'; break;
                        case 'R': currentRotation = 'S'; break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(roverX + " " + roverY + " " + currentRotation);    
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

            rover1Position = Console.ReadLine().ToUpper();
            while (true)
            {
                Regex regex = new Regex(@"^\d\d[NWSE]$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(rover1Position))
                    break;
                else
                {
                    Console.WriteLine("Wrong input! example: 12N");
                }
                rover1Position = Console.ReadLine().ToUpper();
            }
        
            rover1X = Convert.ToInt32(rover1Position[0].ToString());
            rover1Y = Convert.ToInt32(rover1Position[1].ToString());


            rover1Movement = Console.ReadLine().ToUpper();
            while (true)
            {
                Regex regex = new Regex(@"^[LRM]*$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(rover1Movement))
                    break;
                else
                {
                    Console.WriteLine("Wrong input! example: LMLMLMLMM");
                }
                rover1Movement = Console.ReadLine().ToUpper();
            }

            rover2Position = Console.ReadLine().ToUpper();
            while (true)
            {
                Regex regex = new Regex(@"^\d\d[NWSE]$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(rover2Position))
                    break;
                else
                {
                    Console.WriteLine("Wrong input! example: 33E");
                }
                rover2Position = Console.ReadLine().ToUpper();
            }

            rover2X = Convert.ToInt32(rover2Position[0].ToString());
            rover2Y = Convert.ToInt32(rover2Position[1].ToString());

            rover2Movement = Console.ReadLine().ToUpper();
            while (true)
            {
                Regex regex = new Regex(@"^[LRM]*$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(rover2Movement))
                    break;
                else
                {
                    Console.WriteLine("Wrong input! example: MMRMMRMRRM");
                }
                rover2Movement = Console.ReadLine().ToUpper();
            }

        }
    }
}
