using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaModel
{
    public interface IRover
    {
        void CalculatePoint(int edgeX, int edgeY);
    }
    public class Rover : IRover
    {
        public Rover(string startPosition, string movement)
        {
            X = Convert.ToInt32(startPosition[0].ToString());
            Y = Convert.ToInt32(startPosition[1].ToString());
            Rotation = startPosition[2];
            Movement = movement;
        }
        public string Position { get { return X + "" + Y + "" + Rotation; } }
        public string Movement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char Rotation { get; set; }

        public void CalculatePoint(int edgeX, int edgeY)
        {
            foreach (var item in Movement)
            {
                if (Rotation == 'N')
                {
                    switch (item)
                    {
                        case 'M': if (edgeY >= Y + 1) Y++; break;
                        case 'L': Rotation = 'W'; break;
                        case 'R': Rotation = 'E'; break;
                        default:
                            break;
                    }
                }
                else if (Rotation == 'S')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= Y - 1) Y--; break;
                        case 'L': Rotation = 'E'; break;
                        case 'R': Rotation = 'W'; break;
                        default:
                            break;
                    }
                }
                else if (Rotation == 'W')
                {
                    switch (item)
                    {
                        case 'M': if (0 <= X - 1) X--; break;
                        case 'L': Rotation = 'S'; break;
                        case 'R': Rotation = 'N'; break;
                        default:
                            break;
                    }
                }
                else if (Rotation == 'E')
                {
                    switch (item)
                    {
                        case 'M': if (edgeX >= X + 1) X++; break;
                        case 'L': Rotation = 'N'; break;
                        case 'R': Rotation = 'S'; break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(Position);
        }
    }
}
