using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaRover.Model
{
    public class Rover
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
    }
}
