using HepsiBuradaRover.Model;
using System;
using System.Text.RegularExpressions;

namespace HepsiBuradaRover
{
    class Program
    {
        static string upperRight;
        static int edgeX, edgeY;
        readonly static int roverCount = 2;
        static Rover[] roverList = new Rover[roverCount];
        static void Main(string[] args)
        {
            GetInputs();

            foreach (var rover in roverList)
            {
                CalculatePoint(rover);
            }
              
        }

        private static void CalculatePoint(Rover rover)
        {
            foreach (var item in rover.Movement)
            {
                if (rover.Rotation == 'N')
                {
                    switch (item)
                    {
                        case 'M': if (edgeY >= rover.Y + 1) rover.Y++; break;
                        case 'L': rover.Rotation = 'W'; break;
                        case 'R': rover.Rotation = 'E'; break;
                        default:
                            break;
                    }
                }
                else if (rover.Rotation == 'S')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= rover.Y - 1) rover.Y--; break;
                        case 'L': rover.Rotation = 'E'; break;
                        case 'R': rover.Rotation = 'W'; break;
                        default:
                            break;
                    }
                }
                else if (rover.Rotation == 'W')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= rover.X - 1) rover.X--; break;
                        case 'L': rover.Rotation = 'S'; break;
                        case 'R': rover.Rotation = 'N'; break;
                        default:
                            break;
                    }
                }
                else if (rover.Rotation == 'E')
                {
                    switch (item)
                    {
                        case 'M': if (edgeX >= rover.X + 1) rover.X++; break;
                        case 'L': rover.Rotation = 'N'; break;
                        case 'R': rover.Rotation = 'S'; break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(rover.Position);    
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
